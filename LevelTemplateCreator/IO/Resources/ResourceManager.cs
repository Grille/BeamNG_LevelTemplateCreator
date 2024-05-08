using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTemplateCreator.IO.Resources;

internal static class ResourceManager
{
    public static Resource ParseRelative(string entry, string rootPath)
    {
        if (entry.StartsWith('.'))
        {
            var abspackpath = Path.GetFullPath(EnvironmentInfo.Packages.Path);
            var dirpath = Path.GetDirectoryName(rootPath);
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
            var name = entry.Substring(1);

            var key = $"#{name}.png";

            int color;

            if (!int.TryParse(name, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out color))
            {
                SolidColorNames.TryGet(entry, out color);
            }

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
}
