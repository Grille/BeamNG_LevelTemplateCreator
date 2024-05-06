using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTemplateCreator.SceneTree.Main;

internal class SimGroup : SimItem
{
    public class SimGroupItems : IReadOnlyList<SimItem>
    {
        List<SimItem> _items;

        public SimGroupItems() { 
            _items = new List<SimItem>();
        }

        public int Count => _items.Count;

        public SimItem this[int index] => _items[index];

        public void Add(params SimItem[] items)
        {
            foreach (var item in items)
            {
                _items.Add(item);
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => _items.GetEnumerator();

        public IEnumerator<SimItem> GetEnumerator() => _items.GetEnumerator();
    }

    public bool IsMain { get; set; } = false;

    public SimGroupItems Items { get; }

    public SimGroup(JsonDict dict) : base(dict)
    {
        Items = new SimGroupItems();
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
        var items = Items;

        using var tw = new StreamWriter(stream);
        foreach (var item in Items)
        {
            item.SetParent(IsMain ? null : this);
            item.Serialize(stream);
            stream.WriteByte((byte)'\n');
        }
    }

    public const string FileName = "items.level.json";

    public void SaveTree(string path)
    {
        Directory.CreateDirectory(path);


        SetParent(null);
        var filePath = Path.Combine(path, FileName);
        SerializeItems(filePath);

        foreach (var item in Items)
        {
            if (item is SimGroup)
            {
                var childPath = Path.Combine(path, item.Name.Value);
                Directory.CreateDirectory(childPath);
                ((SimGroup)item).SaveTree(childPath);
            }
        }
    }

    public override void CopyTo(JsonDictWrapper target)
    {
        throw new NotSupportedException();
    }
}
