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

namespace LevelTemplateCreator.IO.Resources;

internal class ResourceCollection : KeyedCollection<Resource>
{
    public string Register(string entry)
    {
        var resource = ResourceManager.Parse(entry);
        var key = resource.Name;
        if (ContainsKey(key))
            return key;
        Add(resource);
        return key;
    }

    public string RegisterRelative(string entry, string rootPath)
    {
        var resource = ResourceManager.ParseRelative(entry, rootPath);
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
