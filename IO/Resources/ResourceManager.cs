using System;
using System.Collections;
using System.Globalization;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LevelTemplateCreator.SceneTree.Art;

namespace LevelTemplateCreator.IO.Resources;

internal class ResourceManager : IEnumerable<Resource>
{
    public Dictionary<string, Resource> Files { get; }

    public ResourceManager()
    {
        Files = new Dictionary<string, Resource>();
    }

    public Resource Get(string key)
    {
        return Files[key];
    }

    public Resource this[string key] => Get(key);

    public void Add(Resource ressource)
    {
        if (Files.ContainsKey(ressource.Name))
            return;
        Files[ressource.Name] = ressource;
    }

    public string Register(string entry)
    {
        var resource = Parse(entry);
        Add(resource);
        return resource.Name;
    }

    public string Register(string entry, string file)
    {
        var resource = Parse(entry, file);
        Add(resource);
        return resource.Name;
    }

    public static Resource Parse(string entry, string file)
    {
        if (entry.StartsWith('.'))
        {
            var abspackpath = Path.GetFullPath(EnvironmentInfo.Packages.Path);
            var dirpath = Path.GetDirectoryName(file);
            if (dirpath == null)
                throw new Exception();
            var path = Path.GetFullPath(Path.Combine(dirpath, entry));
            var subpath = path.Substring(abspackpath.Length);

            return Parse(subpath);
        }
        return Parse(entry);
    }

    public static Resource Parse(string entry)
    {
        entry = entry.Replace("\\", "/");

        if (entry.StartsWith('#'))
        {
            var hex = entry.Substring(1);


            int color;
            try
            {
                color = int.Parse(hex, NumberStyles.HexNumber);
            }
            catch { 
                throw new Exception($"Could not parse color '{entry}'");
            }

            var key = $"rgb#{hex}.png";

            var resource = new SolidColorResource(key, color);
            return resource;
        }
        else if (entry.StartsWith('/'))
        {
            var split = entry.ToLower().Split([Path.PathSeparator, Path.AltDirectorySeparatorChar]);

            if (split[1] == "levels")
            {
                var level = split[2];
                var filename = split[split.Length - 1];
                var key = $"beamng.{level}.{filename}";
                var zippath = $"{EnvironmentInfo.GameData.Path}/content/levels/{level}.zip";
                if (File.Exists(zippath))
                {
                    var subpath = entry.Substring(1);
                    var resource = new ZipFileResource(key, zippath, subpath);
                    return resource;
                }
            }

            {
                var filename = entry.Substring(1).Replace("/", ".");
                var key = $"local.{filename}";
                var fpath = Path.Join(EnvironmentInfo.Packages.Path, entry);
                var resource = new FileResource(key, fpath);
                return resource;
            }
        }

        throw new Exception();
    }

    public void Save(string path)
    {
        foreach (var resource in Files.Values)
        {
            var dstpath = Path.Combine(path, resource.Name);
            resource.Save(dstpath);
        }
    }

    public IEnumerator<Resource> GetEnumerator()
    {
        return Files.Values.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return Files.Values.GetEnumerator();
    }
}
