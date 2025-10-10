using System.Threading;

namespace Grille.BeamNG.IO.Resources;

public static class PathEvaluator
{
    public static string[] Split(string entry)
    {
        return entry.ToLower().Split([Path.PathSeparator, Path.AltDirectorySeparatorChar]);
    }

    /*
    static public Resource Get(string entry)
    {
        return Get(entry, BeamEnvironment.Drive.GameDirectory, BeamEnvironment.Drive.CurrentDirectory);
    }
    */

    static public Resource Get(string entry, string gamePath, string userPath)
    {
        entry = entry.Replace("\\", "/");

        string path = entry.StartsWith('/') ? entry.Substring(1) : entry;
        return ParseAbsolute(path, gamePath, userPath);
    }

    static Resource ParseAbsolute(string entry, string gamePath, string userPath)
    {
        var split = Split(entry);

        if (split[0] == "levels")
        {
            var level = split[1];
            var filename = split[split.Length - 1];
            var key = $"{filename}";
            var zippath = $"{gamePath}/content/levels/{level}.zip";
            if (File.Exists(zippath))
            {
                return new ZipFileResource(key, zippath, entry, true);
            }
        }

        throw new NotImplementedException();
    }


}
