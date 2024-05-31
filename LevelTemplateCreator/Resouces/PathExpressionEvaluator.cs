using Grille.BeamNG;
using Grille.BeamNG.IO.Resources;
using LevelTemplateCreator.Assets;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTemplateCreator.IO.Resources;

public static class PathExpressionEvaluator
{
    public static Resource Get(string entry, AssetSource source)
    {
        return Get(entry, source.SourceFile, source.Namespace);
    }

    public static Resource Get(string entry)
    {
        return Get(entry, string.Empty, string.Empty);
    }

    public static Resource Get(string entry, string filePath)
    {
        return Get(entry, filePath, string.Empty);
    }

    public static Resource Get(string entry, string filePath, string @namespace)
    {
        if (entry.StartsWith('$'))
        {
            return ParseVariable(entry, @namespace);
        }
        else if (entry.StartsWith('#'))
        {
            return ParseColor(entry);
        }
        else if (entry.StartsWith('.'))
        {
            return ParseRelative(entry, EnvironmentInfo.Packages.Path, filePath);
        }
        return PathEvaluator.Get(entry, EnvironmentInfo.GameData.Path, EnvironmentInfo.UserData.Path);
    }

    static Resource ParseRelative(string entry, string rootPath, string filePath)
    {
        entry = entry.Replace("\\", "/");

        if (string.IsNullOrEmpty(rootPath))
        {
            throw new ArgumentException("Relative path not supported, RootPath is empty.");
        }
        if (string.IsNullOrEmpty(filePath))
        {
            throw new ArgumentException("Relative path not supported, FilePath is empty.");
        }

        var abspackpath = Path.GetFullPath(rootPath);
        var dirpath = Path.GetDirectoryName(filePath);
        if (dirpath == null)
        {
            throw new InvalidOperationException($"Relative path directory was null '{entry}'");
        }

        var path = Path.GetFullPath(Path.Combine(dirpath, entry));
        var subpath = path.Substring(abspackpath.Length);

        var filename = subpath.Substring(1).Replace("/", "_").Replace("\\", "_");
        var key = $"Local_{filename}";
        var fpath = Path.Join(rootPath, subpath);
        var resource = new FileResource(key, fpath, false);
        return resource;
    }

    static Resource ParseVariable(string entry, string @namespace)
    {
        var name = entry.Substring(1);
        var key = '$' + @namespace + name;

        if (Variables.TryGet(key, out var value))
        {
            return Get(value);
        }
        else
        {
            throw new Exception($"Constant '{key}' not defined.");
        }
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
}
