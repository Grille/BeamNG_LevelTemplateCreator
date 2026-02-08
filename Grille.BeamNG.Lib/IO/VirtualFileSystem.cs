using Grille.BeamNG.IO.Resources;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grille.BeamNG.IO;

public class VirtualFileSystem
{
    public VirtualDirectory Root { get; } = new();

    public bool IsValid { get; private set; }

    private string? _userPath;
    private string? _gamePath;

    public void Invalidate()
    {
        IsValid = false;
    }

    public void Invalidate(string? userCurrentPath, string? gamePath = null)
    {
        _userPath = userCurrentPath;
        _gamePath = gamePath;
        Invalidate();
    }

    public void Update(string? userCurrentPath, string? gamePath = null)
    {
        _userPath = userCurrentPath;
        _gamePath = gamePath;

        void AddArchives(string root, bool isGameResource = false)
        {
            if (!Directory.Exists(root))
                return;

            foreach (var file in Directory.EnumerateFiles(root, "*.zip", SearchOption.TopDirectoryOnly))
            {
                Root.AddZipArchive(file, isGameResource);
            }
        }

        Root.Directories.Clear();
        Root.Files.Clear();

        ZipFileManager.BeginPooling();

        if (_userPath != null)
        {
            Root.AddDirectory(_userPath, false);
            AddArchives(Path.Combine(_userPath, "mods/repo"), false);
        }

        if (_gamePath != null)
        {
            Root.AddZipArchive(Path.Combine(_gamePath, "gameengine.zip"), true);
            AddArchives(Path.Combine(_gamePath, "content"), true);
            AddArchives(Path.Combine(_gamePath, "content/assets"), true);
            AddArchives(Path.Combine(_gamePath, "content/assets/materials"), true);
            AddArchives(Path.Combine(_gamePath, "content/cache"), true);
            AddArchives(Path.Combine(_gamePath, "content/levels"), true);
            AddArchives(Path.Combine(_gamePath, "content/vehicles"), true);
        }

        ZipFileManager.EndPooling();

        IsValid = true;
    }

    public void Update(BeamEnvironment.Product product)
    {
        Update(product.UserCurrentDirectory, product.GameDirectory);
    }

    public bool TryGetFile(string path, [MaybeNullWhen(false)] out Resource resource)
    {
        LazyUpdate();

        if (Root.TryGetFile(path, out resource))
        {
            return true; 
        }

        var ext = Path.GetExtension(path).ToLower();

        if (ext == ".png")
        {
            if (Root.TryGetFile(Path.ChangeExtension(path, ".dds"), out resource))
            {
                return true;
            }
        }
        else if (ext == ".dae")
        {
            if (Root.TryGetFile(Path.ChangeExtension(path, ".cdae"), out resource))
            {
                return true;
            }
        }

        if (Root.TryGetFile($"{path}.link", out var linkfile))
        {
            var link = AssetLink.Deserialize(linkfile.Open());
            if (TryGetFile(link.Path, out resource))
            {
                return true;
            }
        }
        return false;
    }

    public Resource GetFile(string path)
    {
        if (TryGetFile(path, out var resource))
        {
            return resource;
        }
        else
        {
            throw new FileNotFoundException($"Resource '{path}' not found in virtual file system.");
        }
    }

    public Stream OpenFile(string path)
    {
        var resource = GetFile(path);
        return resource.Open();
    }

    public void SaveFile(string path, Stream data)
    {
        if (_userPath == null)
        {
            throw new InvalidOperationException("User path is not set. Cannot save file.");
        }
        var filepath = Path.Combine(_userPath, path);
        var dirpath = Path.GetDirectoryName(filepath);
        Directory.CreateDirectory(dirpath!);
        using var dst = File.OpenWrite(filepath);
        data.CopyTo(dst);

        Invalidate();
    }

    public void SaveFile(string path, Resource data)
    {
        using var stream = data.Open();
        SaveFile(path, stream);
    }


    private void LazyUpdate()
    {
        if (!IsValid)
        {
            Update(_userPath, _gamePath);
        }
    }

    public string[] GetLevelKeys()
    {
        LazyUpdate();
        return Root.GetDirectory("Levels").Directories.Keys.ToArray();
    }

    public string[] GetVehicleKeys()
    {
        LazyUpdate();
        return Root.GetDirectory("Vehicles").Directories.Keys.ToArray();
    }
}
