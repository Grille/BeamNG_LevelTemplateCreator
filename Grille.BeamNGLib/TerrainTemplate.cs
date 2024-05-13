using Grille.BeamNgLib.IO;

namespace Grille.BeamNgLib;

/// <summary>Abstract representation of terrain properties, useful to generate blank terrain files.</summary>
public class TerrainTemplate
{
    private int resolution;

    private float size;
    private float squareSize;

    public int Resolution
    {
        get => resolution;
        set
        {
            resolution = value;
            size = squareSize * resolution;
        }
    }

    public float SquareSize
    {
        get => squareSize;
        set
        {
            squareSize = value;
            size = squareSize * resolution;
        }
    }

    public float WorldSize
    {
        get => size;
        set
        {
            size = value;
            squareSize = size / resolution;
        }
    }

    public float MaxHeight { get; set; }

    public float Height { get; set; }

    public IReadOnlyCollection<string> MaterialNames { get; set; }

    public ushort U16Height
    {
        get => TerrainV9Serializer.GetU16Height(Height, MaxHeight);
        set => Height = TerrainV9Serializer.GetSingleHeight(value, MaxHeight);
    }

    public TerrainTemplate()
    {
        resolution = 1024;
        size = 1024;
        squareSize = 1;
        MaxHeight = 512;
        Height = 10;
        MaterialNames = Array.Empty<string>();
    }

    public void Save(string filePath)
    {
        TerrainV9Serializer.Save(filePath, this);
    }
}
