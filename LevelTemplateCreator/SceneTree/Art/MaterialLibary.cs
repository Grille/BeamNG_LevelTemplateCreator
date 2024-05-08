using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using LevelTemplateCreator.IO;
using LevelTemplateCreator.IO.Resources;
using LevelTemplateCreator.Properties;
using LevelTemplateCreator.Assets;

namespace LevelTemplateCreator.SceneTree.Art;

internal abstract class MaterialLibary
{
    public const string FileName = "main.materials.json";

    public string TexturesPath { get; }

    public ResourceCollection Textures { get; }

    public List<JsonDictWrapper> Misc { get; }

    public abstract IEnumerable<Material> Materials { get; }

    public MaterialLibary(string path)
    {
        TexturesPath = path;
        Misc = new();
        Textures = new();
    }
}

internal abstract class MaterialLibary<T> : MaterialLibary where T : Material
{
    public override List<T> Materials { get; }

    public MaterialLibary(string path) : base(path)
    {
        Materials = new();
    }

    public abstract void AddAsset<TAsset>(TAsset asset) where TAsset : MaterialAsset<T>;

    public void AddAssets<TAsset>(IEnumerable<TAsset> assets, ErrorLogger logger) where TAsset : MaterialAsset<T>
    {
        foreach (var asset in assets)
        {
            try
            {
                AddAsset(asset);
            }
            catch (Exception e) {
                logger.Add($"At {asset.DisplayName} From {asset.SourceFile}\n{e.Message}");
            }
        }
    }


    public string[] GetMaterialNames()
    {
        var result = new string[Materials.Count];
        for (int i = 0; i < result.Length; i++)
        {
            result[i] = Materials[i].Name.Value;
        }
        return result;
    }

    public void SerializeItems(string path)
    {
        using var stream = new FileStream(path, FileMode.Create);
        SerializeItems(stream);
    }

    public void SerializeItems(Stream stream)
    {
        var dict = new JsonDict();

        foreach (var item in Materials)
        {
            dict[item.Name.Value] = item.Dict;
        }

        foreach (var item in Misc)
        {
            dict[item.Name.Value] = item.Dict;
        }

        JsonDictSerializer.Serialize(stream, dict, true);
    }
}
