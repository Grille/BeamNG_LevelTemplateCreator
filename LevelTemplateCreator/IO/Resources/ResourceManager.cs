using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LevelTemplateCreator.IO.Resources;

internal static class ResourceManager
{
    public static Resource Parse(string entry, string rootPath, string @namespace)
    {
        if (entry.StartsWith("$"))
        {
            var name = entry.Substring(1);
            var key = '$' + @namespace + name;
            return ParseVariable(key);
        }
        return Parse(entry, rootPath);
    }

    public static Resource Parse(string entry, string rootPath)
    {
        if (entry.StartsWith('.'))
        {
            return ParseRelative(entry, rootPath);
        }
        return Parse(entry);
    }

    public static Resource Parse(string entry)
    {
        if (entry.StartsWith("$"))
        {
            return ParseVariable(entry);
        }

        entry = entry.Replace("\\", "/");

        if (entry.StartsWith('#'))
        {
            return ParseColor(entry);
        }
        else if (entry.StartsWith('/'))
        {
            return ParseAbsolute(entry);
        }
        else
        {
            return ParseAbsolute('/' + entry);
        }
    }

    static Resource ParseVariable(string key)
    {
        if (Constants.TryGet(key, out var value))
        {
            return Parse(value);
        }
        else
        {
            throw new Exception($"Constant '{key}' not defined.");
        }
    }

    static Resource ParseRelative(string rpath, string rootPath)
    {
        var abspackpath = Path.GetFullPath(EnvironmentInfo.Packages.Path);
        var dirpath = Path.GetDirectoryName(rootPath);
        if (dirpath == null)
            throw new Exception();
        var path = Path.GetFullPath(Path.Combine(dirpath, rpath));
        var subpath = path.Substring(abspackpath.Length);

        return Parse(subpath);
    }

    static Resource ParseColor(string hex)
    {
        var name = hex.Substring(1);

        var key = $"#{name}.png";

        int color;

        if (!int.TryParse(name, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out color))
        {
            SolidColorNames.TryGet(hex, out color);
        }

        var resource = new SolidColorResource(key, color);
        return resource;
    }

    static Resource ParseAbsolute(string path)
    {
        var split = path.ToLower().Split([Path.PathSeparator, Path.AltDirectorySeparatorChar]);

        if (split[1] == "levels")
        {
            var level = split[2];
            var filename = split[split.Length - 1];
            var key = $"beamng.{level}.{filename}";
            var zippath = $"{EnvironmentInfo.GameData.Path}/content/levels/{level}.zip";
            if (File.Exists(zippath))
            {
                var subpath = path.Substring(1);
                var resource = new ZipFileResource(key, zippath, subpath);
                return resource;
            }
        }

        {
            var filename = path.Substring(1).Replace("/", ".");
            var key = $"local.{filename}";
            var fpath = Path.Join(EnvironmentInfo.Packages.Path, path);
            var resource = new FileResource(key, fpath);
            return resource;
        }
    }
}
