using LevelTemplateCreator.IO.Resources;
using LevelTemplateCreator.Properties;
using Grille.BeamNG.SceneTree;
using Grille.BeamNG.SceneTree.Art;
using Grille.BeamNG.SceneTree.Main;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Grille.BeamNG.Logging;
using Grille.BeamNG.IO.Resources;

namespace LevelTemplateCreator.Assets;

public class AssetLibaryLoader
{
    public record class Error(string File, Exception Exception)
    {
        public override string ToString()
        {
            return $"At {File}\n{Exception.Message}";
        }
    }

    public bool Debug {  get; set; }

    const string JsonConstant = "Constant";
    const string JsonInclude = "Include";

    public int MaxWrongFileCount { get; set; } = 20;
    int _wrongFileCount = 0;
    bool _exit = false;

    bool _include = false;

    public ErrorLogger Errors { get; }

    public AssetLibary Libary { get; }

    string _currentFile = string.Empty;

    string _currentNamespace = "";

    readonly static HashSet<string> _ignore;

    static AssetLibaryLoader()
    {
        _ignore = new HashSet<string>()
        {
            ".txt",
            ".jpg",
            ".png",
            ".dds",
            ".dae",
        };
    }

    public AssetLibaryLoader(AssetLibary libary)
    {
        Libary = libary;
        Errors = new ErrorLogger();
    }

    void LogException(Exception e)
    {
        if (!_include)
        Errors.Add(new Error(_currentFile, e));
    }

    public void LoadDirectory(string path)
    {
        ZipFileManager.BeginPooling();
        LoadDirectory(path, string.Empty);
        ZipFileManager.EndPooling();
    }

    void LoadDirectory(string path, string @namespace)
    {
        _currentNamespace = @namespace;

        if (_exit)
        {
            return;
        }

        foreach (var file in Directory.EnumerateFiles(path))
        {
            LoadFile(file);
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

    void LoadFile(string path)
    {
        _currentFile = path;
        var ext = Path.GetExtension(path).ToLower();

        try
        {
            if (ext == ".json" || ext == ".cjson")
            {
                LoadJsonFile(path);
            }
            else if (ext == ".cfg")
            {
                LoadCfgFile(path);
            }
            else if (!_ignore.Contains(ext))
            {
                Errors.Add(new Error(path, new Exception("Unsupported file type.")));
                _wrongFileCount += 1;
                if (_wrongFileCount > MaxWrongFileCount)
                {
                    _exit = true;
                }
            }
        }
        catch (Exception e)
        {
            LogException(e);
            if (Debug)
            {
                throw;
            }
        }
    }

    void LoadJsonFile(string path)
    {
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
            if (dict.TryGetValue("name", out var nameObj))
            {
                var name = (string)nameObj;
                throw new Exception($"Object '{name}' has no class.");
            }
            ParseBeamGroup(dict);
            return;
        }
        var className = (string)classObj;

        try
        {
            ParseObject(dict, className);
        }
        catch (Exception e)
        {
            LogException(e);
        }
    }

    void ParseObject(JsonDict dict, string className)
    {
        var createInfo = new AssetSource(_currentFile, _currentNamespace);

        switch (className)
        {
            case JsonConstant:
            {
                ParseConstant(dict);
                break;
            }
            case JsonInclude:
            {
                ParseInclude(dict);
                break;
            }
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
                Libary.GroundCoverMaterials.Add(asset);
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

    void ParseBeamGroup(JsonDict dict)
    {
        if (dict.Count == 0)
        {
            throw new Exception("Empty object.");
        }

        foreach (var item in dict)
        {
            var key = item.Key;
            var obj = (JsonDict)item.Value;
            if (!obj.TryGetValue("name", out var nameObj))
            {
                throw new Exception("Object has no name.");
            }
            var name = (string)nameObj;
            if (name != key)
            {
                throw new Exception($"Key of object:'{key}' and name:'{name}' must be equal.");
            }

            ParseObject(obj);
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

    void ParseInclude(JsonDict dict)
    {
        var path = (string)dict["path"];
        Include(path);
    }

    void ParseConstant(JsonDict dict)
    {
        var key = (string)dict["key"];
        var value = (string)dict["value"];

        SetConstant(key, value);
    }

    public void Print()
    {
        Errors.Print();

        if (_exit)
        {
            Logger.WriteLine($"{_wrongFileCount} Unsupported files encountered. Asset loading was prematurely stopped.", LoggerColor.Red);
            Logger.WriteLine();
        }
    }

    public void LoadCfgFile(string path)
    {
        var lines = File.ReadAllLines(path);

        foreach (var rawline in lines)
        {
            var line = rawline.Trim();

            if (line.StartsWith("include"))
            {
                var include = line.Split('<', 2)[1].Split('>', 2)[0];
                Include(include);
            }
            if (line.StartsWith("$"))
            {
                var split = line.Split(' ', 2);

                if (split.Length != 2)
                    continue;

                var name = split[0].Trim().Substring(1);
                var value = split[1].Trim();

                SetConstant(name, value);
            }
        }
    }

    void SetConstant(string key, string value)
    {
        Constants.Set('$' + _currentNamespace + key, value);
    }

    const string ItemFile = "items.level.json";

    void Include(string path)
    {
        var filename = Path.GetFileName(path);

        var resource = PathExpressionEvaluator.Get(path, _currentFile, _currentNamespace);
        using var stream = resource.Open();

        try
        {
            _include = true;

            if (filename == ItemFile)
            {
                GetItems(stream);
            }
            else
            {
                Deserialize(stream);
            }
        }
        finally
        {
            _include = false;
        }
    }

    void GetItems(Stream stream)
    {
        var items = SimItemsJsonSerializer.Deserialize(stream);
        foreach (var item in items)
        {
            ParseObject(item);
        }
    }
}
