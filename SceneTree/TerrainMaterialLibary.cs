using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using LevelTemplateCreator.IO;
using LevelTemplateCreator.IO.Resources;

namespace LevelTemplateCreator.SceneTree;

internal class TerrainMaterialLibary
{
    public Level Level { get; }

    public ResourceManager Textures { get; }

    public HashSet<TerrainMaterial> Materials { get; }

    public TerrainMaterialLibary(Level level)
    {
        Level = level;
        Materials  = new HashSet<TerrainMaterial>();
        Textures = new ResourceManager();
    }

    public void AddTemplate(TerrainMaterial material)
    {
        var newmaterial = new TerrainMaterial();
        material.CopyTo(newmaterial);


        Materials.Add(newmaterial);
    }

    public void GetTextures()
    {
        foreach (var material in Materials)
        {
            foreach (var layer in material.Levels)
            {
                var texture = Level.Libary.TextureFiles.Get(layer.Texture);
                Textures.Add(texture);
            }
        }
    }

    public void ResolvePaths()
    {
        foreach (var material in Materials)
        {
            material.AddTexturePath($"/levels/{Level.Namespace}/art/terrains");
        }
    }

    public void SerializeItems(string path)
    {
        using var stream = new FileStream(path, FileMode.Create);
        SerializeItems(stream);
    }

    public void SerializeItems(Stream stream)
    {
        var dict = new Dictionary<string, object>();

        var set = new TerrainMaterialTextureSet($"{Level.Namespace}_TerrainMaterialTextureSet");
        dict[set.Name] = set.Dict;

        foreach (var item in Materials)
        {
            dict[item.Name] = item.Dict;
        }

        JsonDictSerializer.Serialize(stream, dict, true);
    }

    public const string FileName = "main.materials.json";
}
