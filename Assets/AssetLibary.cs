using LevelTemplateCreator.Collections;
using LevelTemplateCreator.IO;
using LevelTemplateCreator.IO.Resources;
using LevelTemplateCreator.SceneTree;
using LevelTemplateCreator.SceneTree.Art;
using LevelTemplateCreator.SceneTree.Main;

namespace LevelTemplateCreator.Assets;

internal class AssetLibary
{
    public AssetCollection<LevelObjectsAsset> LevelPresets { get; }

    public AssetCollection<TerrainMaterialAsset> TerrainMaterials { get; }

    public AssetCollection<ObjectMaterialAsset> ObjectMaterials { get; }

    public AssetCollection<GroundCoverAsset> GroundCoverDefinitions { get; }

    public List<GroundCoverInstance> GroundCoverInstances { get; }

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
            AddGroundCoverInstances(GroundCoverInstance.PopFromGroundcover(item.GroundCover), item);
        }
    }

    void AddGroundCoverInstances(GroundCoverInstance[] instances, Asset parent)
    {
        foreach (var item in instances)
        {
            item.ApplyNamespace(parent.Namespace);
            GroundCoverInstances.Add(item);
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
