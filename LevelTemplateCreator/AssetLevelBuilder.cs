using LevelTemplateCreator.Assets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using LevelTemplateCreator.IO.Resources;
using Grille.BeamNG;
using Grille.BeamNG.SceneTree.Main;
using Grille.BeamNG.SceneTree.Art;
using Grille.BeamNG.IO;
using Grille.BeamNG.Logging;
using System.Numerics;
using Grille.BeamNG.IO.Resources;

namespace LevelTemplateCreator;

public class AssetLevelBuilder
{
    public FileCopyMode CopyMode { get; set; }

    public AssetLibary Libary { get; }

    public AssetLibaryContent Content { get; }

    public string Namespace { get; set; }

    public LevelGameInfo Info { get; }

    public TerrainTemplate Terrain { get; }

    public ErrorLogger Errors { get; }

    public AssetLevelBuilder(AssetLibary libary)
    {
        Libary = libary;
        Namespace = "new_pbr_template";
        Info = new LevelGameInfo();
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
            var copy = asset.GetCopy();
            copy.CreatePersistentId();
            copy.MultiplyByMappingScale(asset.SquareSize / Terrain.SquareSize);
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
        ZipFileManager.BeginPooling();

        Content.Preview?.Save(Path.Combine(path, "preview.png"));

        var level = new LevelBuilder(Namespace);

        level.Info = Info;
        level.Terrain = Terrain;

        BuildSimGroup(level);
        BuildArtGroup(level);

        level.SetupDefaultLevelObjects();
        level.SetupDefaultSpawn();
        level.SetupTerrain();
        level.SetupTerrainMaterialNames();

        level.Save(path);

        ZipFileManager.EndPooling();

        EnvironmentInfo.InvalidateFileSystem();
    }
}
