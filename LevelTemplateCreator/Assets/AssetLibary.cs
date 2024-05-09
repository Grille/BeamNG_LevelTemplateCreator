using Grille.BeamNgLib.Logging;
using Grille.BeamNgLib.SceneTree.Main;


namespace LevelTemplateCreator.Assets;

public class AssetLibary
{
    public AssetCollection<LevelObjectsAsset> LevelPresets { get; }

    public AssetCollection<TerrainMaterialAsset> TerrainMaterials { get; }

    public AssetCollection<ObjectMaterialAsset> GroundCoverMaterials { get; }

    public AssetCollection<GroundCoverAsset> GroundCoverDefinitions { get; }

    public List<GroundCoverInstance> GroundCoverInstances { get; }

    public Bitmap? Preview { get; set; }

    public int TotalCount => LevelPresets.Count + TerrainMaterials.Count + GroundCoverMaterials.Count + GroundCoverDefinitions.Count + GroundCoverInstances.Count;

    public AssetLibary()
    {
        LevelPresets = new();
        TerrainMaterials = new();
        GroundCoverMaterials = new();
        GroundCoverDefinitions = new();
        GroundCoverInstances = new();
    }

    public void Clear()
    {
        LevelPresets.Clear();
        TerrainMaterials.Clear(); 
        GroundCoverMaterials.Clear();
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
        Logger.WriteLine($"Assets: {TotalCount}");
        Logger.WriteLine($"- LevelPresets: {LevelPresets.Count}");
        Logger.WriteLine($"- TerrainMaterials: {TerrainMaterials.Count}");
        Logger.WriteLine($"- ObjectMaterials: {GroundCoverMaterials.Count}");
        Logger.WriteLine($"- GroundCoverDefinitions: {GroundCoverDefinitions.Count}");
        Logger.WriteLine($"- GroundCoverInstances: {GroundCoverInstances.Count}");
        Logger.WriteLine();
    }
}
