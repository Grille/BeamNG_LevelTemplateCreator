using LevelTemplateCreator.IO;
using LevelTemplateCreator.SceneTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace LevelTemplateCreator.Assets;

internal class AssetLibaryLoader
{
    public record class Error(string File, Exception Exception);

    public int MaxError { get; set; } = 10;

    public List<Error> Errors { get; }

    public AssetLibary Libary { get; }

    string currentFile = string.Empty;

    public AssetLibaryLoader(AssetLibary libary)
    {
        Libary = libary;
        Errors = new List<Error>();
    }

    public void LoadDirectory(string path)
    {
        if (Errors.Count > MaxError)
            return;

        foreach (var dir in Directory.EnumerateDirectories(path))
        {
            LoadDirectory(dir);
        }

        foreach (var file in Directory.EnumerateFiles(path))
        {
            var ext = Path.GetExtension(file).ToLower();
            if (ext == ".json" || ext == ".cjson")
            {
                try
                {
                    LoadFile(file);
                }
                catch (Exception e)
                {
                    Errors.Add(new Error(file, e));
                }
            }
        }

        var previewPath = Path.Combine(path, "preview.png");
        if (File.Exists(previewPath))
        {
            using (var stream = new FileStream(previewPath, FileMode.Open))
            {
                Libary.Preview = new Bitmap(stream);
            }
        }
    }

    public void LoadFile(string path)
    {
        currentFile = path;
        using var stream = new FileStream(path, FileMode.Open, FileAccess.Read);
        Deserialize(stream);
    }

    void Deserialize(Stream stream)
    {
        var dict = JsonDictSerializer.Deserialize(stream);

        var item = new JsonDictWrapper(dict);

        ParseObject(item);
    }

    void ParseObject(JsonDictWrapper item)
    {
        switch (item.Class.Value)
        {
            case JsonDictSerializer.ArrayClassName:
            {
                ParseArray(item);
                break;
            }
            case LevelPreset.ClassName:
            {
                var preset = new LevelPreset(item, currentFile);
                Libary.LevelPresets.Add(preset);
                break;
            }
            case TerrainPbrMaterialAsset.ClassName:
            {
                var material = new TerrainPbrMaterialAsset(item, currentFile);
                //material.Material.IndexTextures(Libary.TextureFiles, currentFile);
                Libary.TerrainMaterials.Add(material);
                break;
            }
            case ObjectPbrMaterialAsset.ClassName:
            {
                var material = new ObjectPbrMaterialAsset(item, currentFile);
                Libary.ObjectMaterials.Add(material);
                break;
            }
            case GroundCoverAsset.ClassName:
            {
                var groundcover = new GroundCoverAsset(item, currentFile);
                Libary.GroundCoverAssets.Add(groundcover);
                break;
            }
            default:
            {
                throw new Exception($"Unsupported class {item.Class}.");
            }
        }
    }

    void ParseArray(JsonDictWrapper array)
    {
        var items = (JsonDict[])array["items"];
        foreach (var item in items)
        {
            var si = new JsonDictWrapper(item);

            ParseObject(si);
        }
    }
}
