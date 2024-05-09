namespace Grille.BeamNgLib.IO.Resources;

public class FileResource : Resource
{
    public string Path { get; }

    public FileResource(string name, string path, bool isGameResource) : base(name, isGameResource)
    {
        Path = path;
    }

    public override Stream Open()
    {
        return new FileStream(Path, FileMode.Open);
    }
}
