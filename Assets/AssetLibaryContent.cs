using LevelTemplateCreator.Collections;
using LevelTemplateCreator.SceneTree.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTemplateCreator.Assets;
internal class AssetLibaryContent : AssetLibary
{
    public List<GroundCover> GroundCoverObjects { get; }

    public AssetLibaryContent()
    {
        GroundCoverObjects = new List<GroundCover>();
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
            case LevelObjectsAsset preset:
                LevelPresets.Add(preset);
                break;

            case TerrainMaterialAsset material:
                TerrainMaterials.Add(material);
                break;

            default:
                throw new ArgumentException($"{asset.GetType().Name} not supported.");
        }
    }

    public void GetAssets(AssetLibary libary)
    {
        GetGroundCoverInstances(libary);
        GetGroundCoverDefinitions(libary);
        CreateGroundCoverObjects();
        GetMaterials(libary);
    }

    void GetGroundCoverInstances(AssetLibary libary)
    {
        foreach (var item in libary.GroundCoverInstances)
        {
            if (TerrainMaterials.ContainsKey(item.Layer.Value))
            {
                GroundCoverInstances.Add(item);
            }
        }
    }

    void GetGroundCoverDefinitions(AssetLibary libary)
    {
        foreach (var item in GroundCoverInstances)
        {
            var key = item.Parent.Value;

            if (libary.GroundCoverDefinitions.TryGetValue(key, out var obj))
            {
                GroundCoverDefinitions.Add(obj);
            }
        }
    }

    void CreateGroundCoverObjects()
    {
        KeyedCollection<GroundCoverBuilder> builders = new();

        foreach (var item in GroundCoverDefinitions)
        {
            var builder = new GroundCoverBuilder(item);
            builders.Add(builder);
        }


        foreach (var item in GroundCoverInstances)
        {
            var parent = item.Parent.Value;

            if (builders.TryGetValue(parent, out var ass))
            {
                ass.AddInstance(item);
            }
        }

        GroundCoverObjects.Clear();

        foreach (var item in builders)
        {
            GroundCoverObjects.Add(item.Create());
        }
    }

    void GetMaterials(AssetLibary libary)
    {
        foreach (var item in GroundCoverDefinitions)
        {
            var key = item.GroundCover.Material.Value;

            if (libary.ObjectMaterials.TryGetValue(key, out var obj))
            {
                ObjectMaterials.Add(obj);
            }
        }
    }
}
