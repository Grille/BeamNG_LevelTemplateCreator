using LevelTemplateCreator.IO;
using LevelTemplateCreator.IO.Resources;
using LevelTemplateCreator.SceneTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LevelTemplateCreator.Assets;

internal class AssetLibary
{
    public List<LevelPreset> LevelPresets { get; }

    public ResourceManager TextureFiles { get; }

    public List<TerrainMaterialAsset> TerrainMaterials { get; }

    public Bitmap? Preview { get; private set; }

    public AssetLibary()
    {
        LevelPresets = new List<LevelPreset>();
        TextureFiles = new ResourceManager();
        TerrainMaterials = new List<TerrainMaterialAsset>();
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

        var previewPath = Path.Combine(path, "preview.png");
        if (File.Exists(previewPath))
        {
            using (var stream = new FileStream(previewPath, FileMode.Open))
            {
                Preview = new Bitmap(stream);
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

        ParseObject(item);
    }

    void ParseObject(SimItem item)
    {
        switch (item.Class)
        {
            case JsonDictSerializer.ArrayClassName:
                ParseArray(item);
                break;
            case LevelPreset.ClassName:
                var preset = new LevelPreset(item.Dict);
                LevelPresets.Add(preset);
                break;
            case TerrainMaterialAsset.ClassName:
                var material = new TerrainMaterialAsset(item);
                material.Material.IndexTextures(TextureFiles);
                TerrainMaterials.Add(material);
                break;
            default:
                throw new Exception($"Unsupported class {item.Class}.");
        }
    }

    void ParseArray(SimItem array)
    {
        var items = (Dictionary<string, object>[])array["items"];
        foreach (var item in items)
        {
            var si = new SimItem();
            si.Dict = item;

            ParseObject(si);
        }
    }
}
