using System.Threading;

namespace Grille.BeamNG.IO.Resources;

public static class PathEvaluator
{
    static public Resource Get(string entry, string gamePath)
    {
        return Get(entry, gamePath, string.Empty);
    }

    static public Resource Get(string entry, string gamePath, string userPath)
    {
        entry = entry.Replace("\\", "/");

        string path = entry.StartsWith('/') ? entry.Substring(1) : entry;
        return ParseAbsolute(path, gamePath, userPath);
    }

    static Resource ParseAbsolute(string entry, string gamePath, string userPath)
    {
        var split = entry.ToLower().Split([Path.PathSeparator, Path.AltDirectorySeparatorChar]);

        if (split[0] == "levels")
        {
            var level = split[1];
            var filename = split[split.Length - 1];
            var key = $"{level}_{filename}";
            var zippath = $"{gamePath}/content/levels/{level}.zip";
            if (File.Exists(zippath))
            {
                return new ZipFileResource(key, zippath, entry, true);
            }
        }

        throw new NotImplementedException();
    }


}
