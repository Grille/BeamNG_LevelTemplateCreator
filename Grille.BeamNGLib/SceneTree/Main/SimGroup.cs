using Grille.BeamNgLib.Collections;
using Grille.BeamNgLib.IO;
using Grille.BeamNgLib.SceneTree.Art;

namespace Grille.BeamNgLib.SceneTree.Main;

public class SimGroup : SimItem
{
    public bool IsMain { get; set; } = false;

    public KeyedCollection<SimItem> Items { get; }

    public SimGroup(JsonDict dict) : base(dict)
    {
        Items = new();
    }

    public SimGroup(string name) : this(new JsonDict())
    {
        Class.Value = "SimGroup";
        Name.Value = name;
    }

    public void SerializeItems(string path)
    {
        using var stream = new FileStream(path, FileMode.Create);
        SerializeItems(stream);
    }

    public void SerializeItems(Stream stream)
    {
        foreach (var item in Items)
        {
            item.SetParent(IsMain ? null : this);
        }
        ItemsLevelSerializer.Serialize(stream, Items);
    }

    public IEnumerable<T> EnumerateItems<T>() where T : SimItem
    {
        foreach (var item in Items)
        {
            if (item is T)
            {
                yield return (T)item;
            }
        }
    }

    public const string FileName = "items.level.json";

    public void SaveTree(string path)
    {
        Directory.CreateDirectory(path);


        SetParent(null);
        var filePath = Path.Combine(path, FileName);
        SerializeItems(filePath);

        foreach (var item in EnumerateItems<SimGroup>())
        {
            var childPath = Path.Combine(path, item.Name.Value);
            Directory.CreateDirectory(childPath);
            item.SaveTree(childPath);
        }
    }
}
