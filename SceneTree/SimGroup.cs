using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTemplateCreator.SceneTree;

internal class SimGroup : SimItem
{
    public class SimGroupItems : HashSet<SimItem>
    {
        public void Add(params SimItem[] items)
        {
            foreach (var item in items)
            {
                base.Add(item);
            }
        }
    }

    public bool IsMain { get; set; } = false;

    public SimGroupItems Items { get; }


    public SimGroup(string name)
    {
        Class = "SimGroup";
        Name = name;
        Items = new SimGroupItems();
    }

    public void SerializeItems(string path)
    {
        using var stream = new FileStream(path, FileMode.Create);
        SerializeItems(stream);
    }

    public void SerializeItems(Stream stream)
    {
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
                var childPath = Path.Combine(path, item.Name);
                Directory.CreateDirectory(childPath);
                ((SimGroup)item).SaveTree(childPath);
            }
        }
    }

    public override void CopyTo(SimItem target)
    {
        throw new NotSupportedException();
    }
}
