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

internal class MaterialLibary
{
    public string TexturesPath { get; }

    public ResourceManager Textures { get; }

    public List<Material> Materials { get; }

    public List<JsonDictWrapper> Misc { get; }

    public MaterialLibary(string path)
    {
        TexturesPath = path;
        Materials = new();
        Misc = new();
        Textures = new();
    }

    public void AddAsset(MaterialAsset asset)
    {
        var material = asset.Material.Copy();
        material.ResolveTexturePaths(this, asset.SourceFile);

        Materials.Add(material);
    }


    public string[] GetMaterialNames()
    {
        var result = new string[Materials.Count];
        for (int i = 0; i < result.Length; i++)
        {
            result[i] = Materials[i].InternalName.Value;
        }
        return result;
    }

    public void CreateTerrainMaterialTextureSet(string name)
    {
        Misc.Add(new TerrainPbrMaterialTextureSet(name));
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

    public const string FileName = "main.materials.json";
}
