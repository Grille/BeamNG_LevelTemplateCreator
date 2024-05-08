using System;
using System.Collections;
using System.Globalization;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LevelTemplateCreator.SceneTree.Art;
using LevelTemplateCreator.Collections;
using LevelTemplateCreator.Assets;

namespace LevelTemplateCreator.IO.Resources;

internal class ResourceCollection : KeyedCollection<Resource>
{
    public string Register(string entry)
    {
        var resource = ResourceManager.Parse(entry);
        return TryAdd(resource);
    }

    public string RegisterRelative(string entry, AssetInfo info)
    {
        var resource = ResourceManager.Parse(entry, info.SourceFile, info.Namespace);
        return TryAdd(resource);
    }

    string TryAdd(Resource resource)
    {
        var key = resource.Name;
        if (ContainsKey(key))
            return key;
        Add(resource);
        return key;
    }

    public void Save(string path)
    {
        foreach (var resource in this)
        {
            resource.SaveToDirectory(path);
        }
    }
}
