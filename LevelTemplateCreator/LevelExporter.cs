using LevelTemplateCreator.Assets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using LevelTemplateCreator.IO.Resources;
using Grille.BeamNgLib;
using Grille.BeamNgLib.SceneTree.Main;
using Grille.BeamNgLib.SceneTree.Art;
using Grille.BeamNgLib.IO;
using Grille.BeamNgLib.Logging;
using System.Numerics;
using Grille.BeamNgLib.IO.Resources;

namespace LevelTemplateCreator;

public class LevelExporter
{
    public FileCopyMode CopyMode { get; set; }

    public AssetLibary Libary { get; }

    public AssetLibaryContent Content { get; }

    public string Namespace { get; set; }

    public LevelInfo Info { get; }

    public TerrainTemplate Terrain { get; }

    public ErrorLogger Errors { get; }

    public LevelExporter(AssetLibary libary)
    {
        Libary = libary;
        Namespace = "new_pbr_template";
        Info = new LevelInfo();
        Terrain = new TerrainTemplate();
        Terrain.Resolution = 1024;
        Content = new AssetLibaryContent();
        Errors = new ErrorLogger();
    }

    public void BuildArtGroup(LevelBuilder level)
    {
        var root = level.ArtTree;

        BuildArtGroupTerrain(root);
        BuildArtGroupGroundcover(root);
    }

    void BuildArtGroupTerrain(ArtGroupRoot root)
    {
        var path = $"/levels/{Namespace}/art/terrains";

        var group = root.Terrains;
        var materials = group.MaterialItems;

        foreach (var asset in Content.TerrainMaterials)
        {
            float squareSize = asset switch
            {
                TerrainMaterialAsset tma => tma.SquareSize,
                _ => 1
            };

            var copy = asset.GetCopy();
            copy.CreatePersistentId();
            copy.MultiplyMappingScale(squareSize / Terrain.SquareSize);
            copy.EvalPathExpressions(asset, path, group.Resources, CopyMode);
            materials.Add(copy);
        }
    }

    void BuildArtGroupGroundcover(ArtGroupRoot root)
    {
        var path = $"/levels/{Namespace}/art/shapes/groundcover";

        var group = root.Shapes.Groundcover;
        var materials = group.MaterialItems;

        foreach (var asset in Content.GroundCoverMaterials)
        {
            var copy = asset.GetCopy();
            copy.EvalPathExpressions(asset, path, group.Resources, CopyMode);
            materials.Add(copy);
        }

    }

    public void BuildSimGroup(LevelBuilder level)
    {
        var root = level.MainTree;
        var group = root.MissionGroup;
        var levelObject = group.LevelObjects;

        foreach (var preset in Content.LevelPresets)
        {
            preset.Apply(levelObject);
        }

        foreach (var cover in Content.GroundCoverObjects)
        {
            levelObject.Vegatation.Items.Add(cover);
        }
    }

    public void SetContent(Asset[] assets)
    {
        Content.Clear();
        Content.Add(assets);
        Content.Preview = Libary.Preview;
        Content.GetAssets(Libary);
        Content.PrintSumary();
    }

    public void Export(string path)
    {
        Content.Preview?.Save(Path.Combine(path, "preview.png"));

        var level = new LevelBuilder(Namespace);

        level.Info = Info;
        level.Terrain = Terrain;

        BuildSimGroup(level);
        BuildArtGroup(level);

        level.SetupDefaultSpawn();
        level.SetupTerrain();
        level.SetupTerrainMaterialNames();

        level.Save(path);
    }
}
