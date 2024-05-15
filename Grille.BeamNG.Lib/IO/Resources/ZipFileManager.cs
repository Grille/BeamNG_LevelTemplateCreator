﻿using Grille.BeamNG.Logging;
using System.IO.Compression;

namespace Grille.BeamNG.IO.Resources;

public static class ZipFileManager
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

    public static int Count { get; private set; }

    public static bool PoolingActive { get; private set; } = false;

    static ZipFileManager()
    {
        _archives = new();
        Count = 0;
    }

    public static void BeginPooling()
    {
        if (PoolingActive)
            throw new InvalidOperationException();

        PoolingActive = true;
    }

    static string PathToLower(string path)
    {
        return path.ToLower();
    }

    public static ZipArchiveWrapper Open(string path)
    {
        if (!PoolingActive)
            throw new InvalidOperationException();

        var fullpath = Path.GetFullPath(PathToLower(path));

        if (_archives.TryGetValue(fullpath, out var wrapper))
        {
            return wrapper;
        }

        Logger.WriteLine($"Open {fullpath}");
        Count += 1;

        var archive = ZipFile.OpenRead(fullpath);
        var newwrapper = new ZipArchiveWrapper(archive);
        _archives[fullpath] = newwrapper;
        return newwrapper;
    }

    public static void EndPooling()
    {
        if (!PoolingActive)
            throw new InvalidOperationException();

        PoolingActive = false;

        if (Count == 0)
            return;

        foreach (var pair in _archives)
        {
            Logger.WriteLine($"Close {pair.Key}");

            pair.Value.Dispose();
        }
        Logger.WriteLine();

        Count = 0;

        _archives.Clear();
    }
}