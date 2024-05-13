using Grille.BeamNgLib.IO;
using Grille.BeamNgLib.IO.Resources;
using Grille.BeamNgLib.SceneTree.Art;
using Grille.BeamNgLib.SceneTree.Main;
using System.IO;
using System.Reflection.Emit;

namespace Grille.BeamNgLib;

public class LevelBuilder 
{
    public string Namespace { get; set; }

    public LevelInfo Info { get; set; }

    public TerrainTemplate Terrain { get; set; }

    public SimGroupRoot MainTree {  get; set; }

    public ArtGroupRoot ArtTree { get; set; }

    public Resource? Preview { get; set; }

    bool _setup;

    public LevelBuilder(string @namespace)
    {
        Namespace = @namespace;

        Info = new LevelInfo();
        Terrain = new TerrainTemplate();

        MainTree = new SimGroupRoot();
        ArtTree = new ArtGroupRoot();
    }

    /// <summary>
    /// Call all <c>Setup-...</c> methods, 
    /// </summary>
    public void Setup()
    {

    }

    /// <summary>Creates default <see cref="SpawnSphere"/> object.</summary>
    public void SetupDefaultSpawn()
    {
        var spawn = new SpawnSphere(Terrain.Height);
        MainTree.MissionGroup.PlayerDropPoints.Items.Add(spawn);
    }

    /// <summary>Creates <see cref="TerrainBlock"/> and <see cref="TerrainMaterialTextureSet"/> objects.</summary>
    public void SetupTerrain()
    {
        var textureSetName = $"{Namespace}_TerrainMaterialTextureSet";

        var terrain = new TerrainBlock(Terrain);
        terrain.TerrainFile.Value = $"\\levels\\{Namespace}\\terrain.ter";
        terrain.MaterialTextureSet.Value = textureSetName;
        MainTree.MissionGroup.LevelObjects.Terrain.Items.Add(terrain);

        var textureSet = new TerrainMaterialTextureSet(textureSetName);
        ArtTree.Terrains.MaterialItems.Add(textureSet);
    }

    public void SetupTerrainMaterialNames()
    {
        var names = new List<string>();
        foreach (var item in ArtTree.MaterialItems.EnumerateRecursive<TerrainMaterial>())
        {
            names.Add(item.InternalName);
        }
        Terrain.MaterialNames = names.ToArray();
    }

    public void Save(string dirPath)
    {
        ZipFileManager.BeginPooling();

        var infoPath = Path.Combine(dirPath, "info.json");
        Info.Size.Value = new Vector2(Terrain.WorldSize);
        Info.Save(infoPath);

        var simPath = Path.Combine(dirPath, "main");
        MainTree.SaveTree(simPath);

        var artPath = Path.Combine(dirPath, "art");
        ArtTree.SaveTree(artPath);

        var terrainPath = Path.Combine(dirPath, "terrain.ter");
        Terrain.Save(terrainPath);


        if (Info.Previews.Exists && Info.Previews.Value.Length > 0 && Preview != null)
        {
            var previewPath = Path.Combine(dirPath, Info.Previews.Value[0]);
            Preview.Save(previewPath);
        }

        ZipFileManager.EndPooling();
    }
}
