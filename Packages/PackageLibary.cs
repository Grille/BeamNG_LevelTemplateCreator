using LevelTemplateCreator.IO;
using LevelTemplateCreator.SceneTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LevelTemplateCreator.Packages;

internal class PackageLibary
{
    //public static Dictionary<string, Texture> Textures { get; }
    public List<LevelPreset> LevelPresets { get; }

    public RessourceFileManager RessourceFiles { get; }

    public List<TerrainMaterialTemplate> TerrainMaterials { get; }

    public PackageLibary()
    {
        LevelPresets = new List<LevelPreset>();
        RessourceFiles = new RessourceFileManager();
        TerrainMaterials = new List<TerrainMaterialTemplate>();
        //Textures = new Dictionary<string, Texture>();
    }

    public void LoadDirectory(string path)
    {
        foreach (var dir in Directory.EnumerateDirectories(path))
        {
            LoadDirectory(dir);
        }

        foreach (var file in Directory.EnumerateFiles(path))
        {
            var ext = Path.GetExtension(file).ToLower();
            if (ext == ".json" || ext == ".cjson")
            {
                LoadFile(file);
            }
        }
    }

    public void LoadFile(string path)
    {
        using var stream = new FileStream(path, FileMode.Open, FileAccess.Read);
        LoadFile(stream);
    }

    public void LoadFile(Stream stream)
    {
        var dict = JsonDictSerializer.Deserialize(stream);

        var item = new SimItem();
        item.Dict = dict;

        ParseFile(item);
    }

    void ParseFile(SimItem item)
    {
        switch (item.Class)
        {
            case "Template_Array":
                ParseArray(item);
                break;
            case "Template_LevelPreset":
                var preset = new LevelPreset(item.Dict);
                LevelPresets.Add(preset);
                break;
            case "Template_TerrainMaterial":
                ParseMaterialLib(item);
                break;
            default:
                throw new Exception();
        }
    }

    void ParseArray(SimItem array)
    {
        var items = (Dictionary<string, object>[])array["items"];
        foreach (var item in items)
        {
            var si = new SimItem();
            si.Dict = item;

            ParseFile(si);
        }
    }

    void ParseMaterialLib(SimItem item)
    {
        var material = new TerrainMaterial();
        material.Dict = item.Dict;

        material.Class = "TerrainMaterial";
        material.PersistentId = "id";
        material.InternalName = material.Name;
        material.Name = $"{material.InternalName}_{material.PersistentId}";

        var template = new TerrainMaterialTemplate();
        template.Material = material;

        TerrainMaterials.Add(template);
    }
}
