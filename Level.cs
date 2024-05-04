using LevelTemplateCreator.IO;
using LevelTemplateCreator.Packages;
using LevelTemplateCreator.SceneTree;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTemplateCreator;

internal class Level
{
    public string Namespace { get; set; }

    public LevelInfo Info { get; set; }

    public List<TerrainMaterial> Materials { get; set; }

    public TerrainInfo Terrain { get; set; }

    public LevelPreset LevelPreset { get; set; }

    public Level()
    {
        Namespace = "new_pbr_template";
        Info = new LevelInfo();
        Terrain = new TerrainInfo()
        {
            Resolution = 1024,
        };
        Materials = new List<TerrainMaterial>();
    }

    public TerrainBlock BuildTerrainBlock()
    {
        var terrain = new TerrainBlock(Terrain);
        terrain.TerrainFile = $"\\levels\\{Namespace}\\terrain.ter";
        terrain.MaterialTextureSet = $"{Namespace}_TerrainMaterialTextureSet";
        return terrain;
    }

    public MaterialLib BuildMaterialLibary()
    {
        var lib = new MaterialLib();

        foreach ( var material in Materials) { 
            lib.Items.Add(material);
        }

        lib.Items.Add(new TerrainMaterialTextureSet($"{Namespace}_TerrainMaterialTextureSet"));

        return lib;
    }

    public SimGroup BuildMissionGroup()
    {
        var root = new SimGroup("main")
        {
            IsMain = true
        };

        var group = new SimGroup("MissionGroup");

        var playerDropPoints = new SimGroup("PlayerDropPoints");

        var levelObject = new SimGroupLevelObject();

        var theTerrain = BuildTerrainBlock();
        levelObject.Terrain.Items.Add(theTerrain);

        root.Items.Add(group);
        group.Items.Add(levelObject);
        group.Items.Add(playerDropPoints);

        LevelPreset.Apply(levelObject);

        return root;
    }

    public void Export(string path)
    {
        Directory.CreateDirectory(Path.Combine(path, "art/terrains"));

        BuildMaterialLibary().SerializeItems(Path.Combine(path, "art/terrains/" + MaterialLib.FileName));

        BuildMissionGroup().SaveTree(Path.Combine(path, "main"));

        TerrainV9Serializer.Serialize(Terrain, Materials, Path.Combine(path, "terrain.ter"));

        Properties.Resources.Preview.Save(Path.Combine(path, "Preview.jpg"));

        LevelInfoSerializer.Serialize(this, Path.Combine(path, "info.json"));
    }
}
