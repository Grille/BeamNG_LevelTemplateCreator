using LevelTemplateCreator.IO;
using LevelTemplateCreator.SceneTree;
using LevelTemplateCreator.SceneTree.Art;
using LevelTemplateCreator.SceneTree.Main;

namespace LevelTemplateCreator.Assets;

internal class AssetLibaryLoader
{
    public record class Error(string File, Exception Exception);

    public bool Debug {  get; set; }

    public int MaxError { get; set; } = 50;

    public List<Error> Errors { get; }

    public AssetLibary Libary { get; }

    string _currentFile = string.Empty;

    string _currentNamespace = "";

    public AssetLibaryLoader(AssetLibary libary)
    {
        Libary = libary;
        Errors = new List<Error>();
    }

    void LogException(Exception e)
    {
        Errors.Add(new Error(_currentFile, e));
    }

    public void LoadDirectory(string path)
    {
        LoadDirectory(path, string.Empty);
    }

    public void LoadDirectory(string path, string @namespace)
    {
        _currentNamespace = @namespace;

        if (Errors.Count > MaxError)
            return;

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
                    LogException(e);
                    if (Debug)
                        throw;
                }
            }
        }



        foreach (var dir in Directory.EnumerateDirectories(path))
        {
            var name = Path.GetFileName(dir);

            var newNamespace = @namespace + name + "_";

            LoadDirectory(dir, newNamespace);
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
        _currentFile = path;
        using var stream = new FileStream(path, FileMode.Open, FileAccess.Read);
        Deserialize(stream);
    }

    void Deserialize(Stream stream)
    {
        var dict = JsonDictSerializer.Deserialize(stream);
        ParseObject(dict);
    }

    void ParseObject(JsonDict dict)
    {
        if (!dict.TryGetValue("class", out var classObj))
        {
            throw new Exception("no class");
        }
        var className = (string)classObj;

        try
        {
            ParseObject(dict, className);
        }
        catch (Exception e)
        {
            LogException(e);
            if (Debug)
                throw;
        }
    }

    void ParseObject(JsonDict dict, string className)
    {
        var createInfo = new AssetCreateInfo(_currentFile, _currentNamespace);

        switch (className)
        {
            case JsonDictSerializer.ArrayClassName:
            {
                ParseArray(dict);
                break;
            }
            case LevelObjectsAsset.ClassName:
            {
                var obj = new JsonDictWrapper(dict);
                var asset = new LevelObjectsAsset(obj, createInfo);
                Libary.LevelPresets.Add(asset);
                break;
            }
            case TerrainMaterialAsset.ClassName:
            {
                var obj = new TerrainMaterial(dict);
                var asset = new TerrainMaterialAsset(obj, createInfo);
                Libary.TerrainMaterials.Add(asset);
                break;
            }
            case ObjectMaterialAsset.ClassName:
            {
                var obj = new ObjectMaterial(dict);
                var asset = new ObjectMaterialAsset(obj, createInfo);
                Libary.ObjectMaterials.Add(asset);
                break;
            }
            case GroundCoverAsset.ClassName:
            {
                var obj = new GroundCover(dict);
                var asset = new GroundCoverAsset(obj, createInfo);
                Libary.GroundCoverDefinitions.Add(asset);
                break;
            }
            default:
            {
                throw new Exception($"Unsupported class {className}.");
            }
        }
    }

    void ParseArray(JsonDict array)
    {
        var items = (JsonDict[])array["items"];
        foreach (var item in items)
        {
            ParseObject(item);
        }
    }

    public void PrintErrors()
    {
        if (Errors.Count == 0)
            return;

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"{Errors.Count} errors while loading assets.");
        Console.ForegroundColor = ConsoleColor.Gray;

        Console.WriteLine();

        for (int i = 0; i < Errors.Count; i++)
        {
            var error = Errors[i];

            Console.WriteLine($"At {error.File}");
            Console.WriteLine(error.Exception.Message);

            Console.WriteLine();
        }

    }
}
