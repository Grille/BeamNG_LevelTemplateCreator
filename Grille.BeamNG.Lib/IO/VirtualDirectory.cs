using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grille.BeamNG.IO.Resources;

namespace Grille.BeamNG.IO;

public class VirtualDirectory
{
    public bool IsRoot { get; }

    public string Name { get; private set; } = string.Empty;

    public Dictionary<string, Resource> Files { get; } = new Dictionary<string, Resource>(StringComparer.OrdinalIgnoreCase);

    public Dictionary<string, VirtualDirectory> Directories { get; } = new Dictionary<string, VirtualDirectory>(StringComparer.OrdinalIgnoreCase);

    internal VirtualDirectory(string name)
    {
        IsRoot = false;
        Name = name;
    }

    public VirtualDirectory()
    {
        IsRoot = true;
    }

    public VirtualDirectory GetDirectory(string? path)
    {
        if (string.IsNullOrEmpty(path))
            return this;

        var parts = path.Split(['/', '\\'], StringSplitOptions.RemoveEmptyEntries);
        return GetDirectory(parts);
    }

    private VirtualDirectory GetDirectory(ReadOnlySpan<string> path)
    {
        if (path.Length == 0)
            return this;

        if (Directories.TryGetValue(path[0], out var dir))
        {
            return dir.GetDirectory(path.Slice(1));
        }
        else
        {
            dir = new VirtualDirectory($"{Name}/{path[0]}");
            Directories[path[0]] = dir;
            return dir.GetDirectory(path.Slice(1));
        }
    }

    public bool TryGetFile(string path, [MaybeNullWhen(false)] out Resource resource)
    {
        var dirpath = Path.GetDirectoryName(path);
        var filename = Path.GetFileName(path);
        var dir = GetDirectory(dirpath);
        return dir.Files.TryGetValue(filename, out resource);
    }

    public Resource GetFile(string path)
    {
        if (TryGetFile(path, out var resource))
        {
            return resource;
        }
        throw new KeyNotFoundException($"File '{path}' not found in virtual directory.");
    }

    public Resource? SearchFile(Predicate<string> match)
    {
        foreach (var file in Files.Values)
        {
            if (match(file.Name))
                return file;
        }
        foreach (var dir in Directories.Values)
        {
            var result = dir.SearchFile(match);
            if (result != null)
                return result;
        }
        return null;
    }

    public void AddZipArchive(string zipFilePath, bool isGameResource)
    {
        if (!IsRoot)
            throw new InvalidOperationException("Can only add zip archives to the root virtual directory.");

        var archive = ZipFileManager.Open(zipFilePath);
        foreach (var entry in archive.Entries)
        {
            var dirpath = Path.GetDirectoryName(entry.FullName);
            var filename = Path.GetFileName(entry.FullName);
            var subdir = GetDirectory(dirpath);
            if (subdir.Files.ContainsKey(filename))
            {
                continue;
            }
            var resource = new ZipFileResource(filename, zipFilePath, entry.FullName, isGameResource);
            subdir.Files[filename] = resource;
        }
    }

    public void AddDirectory(string directoryPath, bool isGameResource)
    {
        var files = Directory.GetFiles(directoryPath, "*", SearchOption.AllDirectories);

        foreach (var file in files)
        {
            var relativePath = Path.GetRelativePath(directoryPath, file);
            var dirpath = Path.GetDirectoryName(relativePath);
            var filename = Path.GetFileName(relativePath);
            var subdir = GetDirectory(dirpath);
            if (subdir.Files.ContainsKey(filename))
            {
                continue;
            }
            var resource = new FileResource(filename, file, isGameResource);
            subdir.Files[filename] = resource;
        }
    }

    public override string ToString()
    {
        return $"{Name}, F{Files.Count}, D{Directories.Count}";
    }
}
