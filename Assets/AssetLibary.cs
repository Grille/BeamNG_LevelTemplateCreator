using LevelTemplateCreator.IO;
using LevelTemplateCreator.IO.Resources;
using LevelTemplateCreator.SceneTree;
using LevelTemplateCreator.SceneTree.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LevelTemplateCreator.Assets;

internal class AssetLibary
{
    public AssetCollection<LevelPreset> LevelPresets { get; }

    public AssetCollection<TerrainPbrMaterialAsset> TerrainMaterials { get; }

    public AssetCollection<ObjectPbrMaterialAsset> ObjectMaterials { get; }

    public AssetCollection<GroundCoverAsset> GroundCoverDefinitions { get; }

    public AssetCollection<GroundCoverInstanceAsset> GroundCoverInstances { get; }

    public Bitmap? Preview { get; set; }

    public int TotalCount => LevelPresets.Count + TerrainMaterials.Count + ObjectMaterials.Count + GroundCoverDefinitions.Count + GroundCoverInstances.Count;

    public AssetLibary()
    {
        LevelPresets = new();
        TerrainMaterials = new();
        ObjectMaterials = new();
        GroundCoverDefinitions = new();
        GroundCoverInstances = new();
    }

    public void Add(IEnumerable<Asset> assets)
    {
        foreach (var asset in assets)
        {
            Add(asset);
        }
    }

    public void Add(Asset asset)
    {
        switch (asset)
        {
            case LevelPreset preset:
                LevelPresets.Add(preset);
                break;

            case TerrainPbrMaterialAsset material:
                TerrainMaterials.Add(material);
                break;

            default:
                throw new ArgumentException();
        }
    }

    public void Clear()
    {
        LevelPresets.Clear();
        TerrainMaterials.Clear(); 
        ObjectMaterials.Clear();
        GroundCoverDefinitions.Clear();
        GroundCoverInstances.Clear();
    }

    public void SeperateGroundCoverInstances()
    {
        foreach (var item in GroundCoverDefinitions)
        {
            AddGroundCoverInstances(GroundCoverInstance.PopFromGroundcover(item.GroundCover), item.SourceFile);
        }

        foreach (var item in TerrainMaterials) {
            AddGroundCoverInstances(GroundCoverInstance.PopFromMaterial(item.Material), item.SourceFile);
        }
    }

    void AddGroundCoverInstances(GroundCoverInstance[] instances, string source)
    {
        foreach (var item in instances)
        {
            var asset = new GroundCoverInstanceAsset(item, source);
            GroundCoverInstances.Add(asset);
        }
    }

    public void GetGroundCoverInstances(AssetCollection<TerrainPbrMaterialAsset> filter, AssetCollection<GroundCoverInstanceAsset> target)
    {
        foreach (var item in GroundCoverInstances)
        {
            if (filter.ConatinsKey(item.Instance.Layer.Value))
            {
                target.Add(item);
            }
        }
    }

    public void CreateGroundCoverObjects(AssetCollection<GroundCoverInstanceAsset> instances)
    {

    }

    public void GetMaterials(AssetCollection<GroundCoverAsset> filter, AssetCollection<ObjectPbrMaterialAsset> target)
    {
        foreach (var item in GroundCoverInstances)
        {
            if (filter.ConatinsKey(item.Instance.Layer.Value))
            {
                //target.Add(item);
            }
        }
    }

    public void PrintSumary()
    {
        Console.WriteLine($"Assets: {TotalCount}");
        Console.WriteLine($"- LevelPresets: {LevelPresets.Count}");
        Console.WriteLine($"- TerrainMaterials: {TerrainMaterials.Count}");
        Console.WriteLine($"- ObjectMaterials: {ObjectMaterials.Count}");
        Console.WriteLine($"- GroundCoverDefinitions: {GroundCoverDefinitions.Count}");
        Console.WriteLine($"- GroundCoverInstances: {GroundCoverInstances.Count}");
        Console.WriteLine();
    }
}
