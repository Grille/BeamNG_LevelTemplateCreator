using Grille.BeamNgLib.Collections;

namespace Grille.BeamNgLib.IO.Resources;

public abstract class Resource : IKeyed
{
    string IKeyed.Key => Name;

    public bool IsGameResource { get; }

    public string Name { get; }

    /// <summary>Gets set when resource is opened.</summary>
    public string DynamicName { get; protected set; }

    public Resource(string name, bool isGameResource)
    {
        Name = name;
        DynamicName = name;
        IsGameResource = isGameResource;
    }

    public abstract Stream Open();

    public void SaveToDirectory(string dirPath)
    {
        using var stream = Open();
        var dstpath = Path.Combine(dirPath, DynamicName);
        using var file = File.OpenWrite(dstpath);
        stream.CopyTo(file);
    }

    public void Save(string filePath)
    {
        using var src = Open();
        using var dst = File.Create(filePath);
        src.CopyTo(dst);
    }
}
