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

    public Level Level { get; set; }

    public LevelInfo Info => Level.Info;

    public TerrainInfo Terrain => Level.Terrain;

    public ErrorLogger Errors { get; }

    public LevelExporter(AssetLibary libary)
    {
        Namespace = "new_pbr_template";
        Level = new();
        Level.Terrain.Resolution = 1024;
        Content = new AssetLibaryContent();
        Libary = libary;
        Errors = new ErrorLogger();
    }

    public TerrainBlock BuildTerrainBlock()
    {
        var terrain = new TerrainBlock(Terrain);
        terrain.TerrainFile.Value = $"\\levels\\{Namespace}\\terrain.ter";
        terrain.MaterialTextureSet.Value = $"{Namespace}_TerrainMaterialTextureSet";
        return terrain;
    }

    public ArtGroupRoot BuildArtGroup()
    {
        var root = new ArtGroupRoot();

        BuildArtGroupTerrain(root);
        BuildArtGroupGroundcover(root);

        return root;
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

        var textureSetName = $"{Namespace}_TerrainMaterialTextureSet";
        materials.Add(new TerrainMaterialTextureSet(textureSetName));
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

    public SimGroupRoot BuildSimGroup()
    {
        var root = new SimGroupRoot();
        var group = root.MissionGroup;
        var levelObject = group.LevelObject;

        var spawn = new SpawnSphere(Terrain.Height);
        group.PlayerDropPoints.Items.Add(spawn);

        var terrain = BuildTerrainBlock();
        levelObject.Terrain.Items.Add(terrain);

        foreach (var preset in Content.LevelPresets)
        {
            preset.Apply(levelObject);
        }

        foreach (var cover in Content.GroundCoverObjects)
        {
            levelObject.Vegatation.Items.Add(cover);
        }

        return root;
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
        LevelInfoSerializer.Save(Path.Combine(path, "info.json"), Level);
        TerrainV9Serializer.Save(Path.Combine(path, "terrain.ter"), Terrain, Content.TerrainMaterials.Keys);

        Content.Preview?.Save(Path.Combine(path, "preview.png"));

        var simPath = Path.Combine(path, "main");
        var artPath = Path.Combine(path, "art");

        BuildSimGroup().SaveTree(simPath);
        BuildArtGroup().SaveTree(artPath);

        ZipFileManager.Clear();
        
        Errors.Print();
        Errors.Clear();
    }
}
