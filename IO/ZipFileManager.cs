using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTemplateCreator.IO;

internal static class ZipFileManager
{
    public class ZipArchiveWrapper : IDisposable
    {
        readonly ZipArchive _archive;

        Dictionary<string, ZipArchiveEntry>? _lEntries;

        public ZipArchiveWrapper(ZipArchive archive)
        {
            _archive = archive;
        }

        public bool TryGetEntry(string name, out ZipArchiveEntry entry)
        {
            var result = _archive.GetEntry(name)!;
            if (result != null)
            {
                entry = result;
                return true;
            }

            if (_lEntries == null)
            {
                _lEntries = new Dictionary<string, ZipArchiveEntry>();

                foreach (var zipentry in _archive.Entries)
                {
                    _lEntries.Add(PathToLower(zipentry.FullName), zipentry);
                }
            }

            var lname = PathToLower(name);
            if (_lEntries.TryGetValue(lname, out result))
            {
                entry = result;
                return true;
            }

            entry = null!;
            return false;
        }

        public ZipArchiveEntry? GetEntry(string name)
        {
            TryGetEntry(name, out var entry);
            return entry;
        }

        public void Dispose() => _archive.Dispose();
    }

    static readonly Dictionary<string, ZipArchiveWrapper> _archives;

    static ZipFileManager()
    {
        _archives = new();
    }

    static string PathToLower(string path)
    {
        return path.ToLower();
    }

    public static ZipArchiveWrapper Open(string path)
    {
        var fullpath = Path.GetFullPath(PathToLower(path));

        if (_archives.TryGetValue(fullpath, out var wrapper))
        {
            return wrapper;
        }

        Console.WriteLine($"Open {fullpath}");

        var archive = ZipFile.OpenRead(fullpath);
        var newwrapper = new ZipArchiveWrapper(archive);
        _archives[fullpath] = newwrapper;
        return newwrapper;
    }

    public static void Clear()
    {
        foreach (var pair in _archives)
        {
            Console.WriteLine($"Close {pair.Key}");
            pair.Value.Dispose();
        }

        _archives.Clear();
    }
}
