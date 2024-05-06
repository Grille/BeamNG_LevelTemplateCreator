﻿using LevelTemplateCreator.IO;
using LevelTemplateCreator.Assets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using LevelTemplateCreator.SceneTree.Art;
using LevelTemplateCreator.SceneTree.Main;
using LevelTemplateCreator.IO.Resources;
using LevelTemplateCreator.Properties;

namespace LevelTemplateCreator;

internal class Level
{
    public AssetLibary Libary { get; }

    public string Namespace { get; set; }

    public LevelInfo Info { get; set; }

    public List<TerrainPbrMaterialAsset> TerrainMaterials { get; set; }

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
        TerrainMaterials = new();
        Libary = libary;
    }

    public TerrainBlock BuildTerrainBlock()
    {
        var terrain = new TerrainBlock(Terrain);
        terrain.TerrainFile.Value = $"\\levels\\{Namespace}\\terrain.ter";
        terrain.MaterialTextureSet.Value = $"{Namespace}_TerrainMaterialTextureSet";
        return terrain;
    }

    public MaterialLibary BuildTerrainMaterialLibary()
    {
        var path = $"/levels/{Namespace}/art/terrains";
        var lib = new MaterialLibary(path);

        foreach (var asset in TerrainMaterials)
        {
            lib.AddAsset(asset);
        }

        lib.CreateTerrainMaterialTextureSet($"{Namespace}_TerrainMaterialTextureSet");

        return lib;
    }

    public SimGroup BuildMissionGroup()
    {
        var root = new SimGroupRoot();
        var group = root.MissionGroup;
        var levelObject = group.LevelObject;

        var terrain = BuildTerrainBlock();
        levelObject.Terrain.Items.Add(terrain);

        LevelPreset?.Apply(levelObject);

        foreach (var cover in Libary.GroundCoverAssets)
        {
            levelObject.Vegatation.Items.Add(cover.Definition);
        }

        return root;
    }

    public void Export(string path)
    {
        Directory.CreateDirectory(Path.Combine(path, "art/terrains"));

        Directory.CreateDirectory(Path.Combine(path, "art/objects"));

        var objpath = $"/levels/{Namespace}/art/objects";
        var lib = new MaterialLibary(objpath);

        foreach (var asset in Libary.ObjectMaterials)
        {
            lib.AddAsset(asset);
        }

        lib.SerializeItems(Path.Combine(path, "art/objects/" + MaterialLibary.FileName));
        lib.Textures.Save(Path.Combine(path, "art/objects"));

        var terrainMaterials = BuildTerrainMaterialLibary();

        terrainMaterials.SerializeItems(Path.Combine(path, "art/terrains/" + MaterialLibary.FileName));

        var texturespath = Path.Combine(path, "art/terrains");

        terrainMaterials.Textures.Save(texturespath);


        Preview?.Save(Path.Combine(path, "preview.png"));


        BuildMissionGroup().SaveTree(Path.Combine(path, "main"));

        var names = terrainMaterials.GetMaterialNames();

        TerrainV9Serializer.Serialize(Terrain, names, Path.Combine(path, "terrain.ter"));

        LevelInfoSerializer.Serialize(this, Path.Combine(path, "info.json"));
    }
}
