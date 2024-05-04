using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using LevelTemplateCreator.IO;

namespace LevelTemplateCreator.SceneTree;

internal class MaterialLib
{
    public HashSet<SimItem> Items { get; } = new();

    public void SerializeItems(string path)
    {
        using var stream = new FileStream(path, FileMode.Create);
        SerializeItems(stream);
    }

    public void SerializeItems(Stream stream)
    {
        var dict = new Dictionary<string, object>();

        foreach (var item in Items)
        {
            dict[item.Name] = item.Dict;
        }

        JsonDictSerializer.Serialize(stream, dict, true);
    }

    public const string FileName = "main.materials.json";
}
