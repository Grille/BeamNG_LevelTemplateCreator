using Grille.BeamNG.Logging;
using System.IO.Compression;
using System.Runtime.InteropServices;
using System.Threading;

namespace Grille.BeamNG.IO;


public static class ZipFileManager
{
    static readonly object _locker = new object();

    public class ZipArchiveWrapper
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

        internal void Dispose() => _archive.Dispose();

        public IEnumerable<ZipArchiveEntry> Entries => _archive.Entries;
    }

    static readonly Dictionary<string, ZipArchiveWrapper> _archives;

    public static int Count => _archives.Count;

    public static int Scope { get; private set; }

    public static bool PoolingActive => Scope > 0;

    static ZipFileManager()
    {
        _archives = new();
    }

    static string PathToLower(string path)
    {
        return path.TrimStart('/').ToLower();
    }

    public static ZipArchiveWrapper Open(string path)
    {
        AssertIsActive();

        var fullpath = Path.GetFullPath(PathToLower(path));

        if (_archives.TryGetValue(fullpath, out var wrapper))
        {
            return wrapper;
        }

        Logger.WriteLine($"Open {fullpath}");

        var archive = ZipFile.OpenRead(fullpath);
        var newwrapper = new ZipArchiveWrapper(archive);
        _archives[fullpath] = newwrapper;
        return newwrapper;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0)]
    public struct PoolingHandle : IDisposable
    {
        public void Dispose() => EndPooling();
    }

    /// <summary></summary>
    /// <remarks>This method is thread safe. Other calls to <see cref="BeginPooling"/> will wait until this session is closed.</remarks>
    /// <returns></returns>
    public static PoolingHandle BeginPooling()
    {
        lock (_locker)
        {
            Scope += 1;
        }
        return new PoolingHandle();
    }

    public static void EndPooling()
    {
        AssertIsActive();

        lock (_locker)
        {
            Scope -= 1;

            if (Count > 0 && Scope == 0)
            {
                foreach (var pair in _archives)
                {
                    Logger.WriteLine($"Close {pair.Key}");

                    pair.Value.Dispose();
                }
                Logger.WriteLine();

                _archives.Clear();
            }

        }
    }

    static void AssertIsActive()
    {
        if (!PoolingActive)
        {
            throw new InvalidOperationException("Pooling is not active. Please call Grille.BeamNG.IO.ZipFileManager.BeginPooling() before any operations.");
        }
    }
}
