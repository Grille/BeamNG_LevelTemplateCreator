using LevelTemplateCreator.IO;
using LevelTemplateCreator.Assets;
using LevelTemplateCreator.SceneTree;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LevelTemplateCreator;

internal class Level
{
    public AssetLibary Libary { get; }
    public string Namespace { get; set; }

    public LevelInfo Info { get; set; }

    public List<TerrainMaterial> Materials { get; set; }

    public TerrainInfo Terrain { get; set; }

    public LevelPreset? LevelPreset { get; set; }

    public Bitmap? Preview { get; set; }

    public Level(AssetLibary libary)
    {
        Namespace = "new_pbr_template";
        Info = new LevelInfo();
        Terrain = new TerrainInfo()
        {
            Resolution = 1024,
        };
        Materials = new List<TerrainMaterial>();
        Libary = libary;
    }

    public TerrainBlock BuildTerrainBlock()
    {
        var terrain = new TerrainBlock(Terrain);
        terrain.TerrainFile = $"\\levels\\{Namespace}\\terrain.ter";
        terrain.MaterialTextureSet = $"{Namespace}_TerrainMaterialTextureSet";
        return terrain;
    }

    public TerrainMaterialLibary BuildMaterialLibary()
    {
        var lib = new TerrainMaterialLibary(this);

        foreach (var material in Materials) {
            lib.AddTemplate(material);
        }

        lib.GetTextures();
        lib.ResolvePaths();

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

        LevelPreset?.Apply(levelObject);

        return root;
    }

    public void Export(string path)
    {


        Directory.CreateDirectory(Path.Combine(path, "art/terrains"));

        var matirials = BuildMaterialLibary();

        matirials.SerializeItems(Path.Combine(path, "art/terrains/" + TerrainMaterialLibary.FileName));

        var texturespath = Path.Combine(path, "art/terrains");

        foreach (var texure in matirials.Textures)
        {
            var texpath = Path.Combine(texturespath, texure.Name);
            texure.Save(texpath);
        }


        Preview?.Save(Path.Combine(path, "preview.png"));


        BuildMissionGroup().SaveTree(Path.Combine(path, "main"));

        TerrainV9Serializer.Serialize(Terrain, Materials, Path.Combine(path, "terrain.ter"));

        LevelInfoSerializer.Serialize(this, Path.Combine(path, "info.json"));
    }
}
