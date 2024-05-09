using Grille.BeamNgLib.IO;

namespace Grille.BeamNgLib;

public class TerrainInfo
{
    private int resolution;

    private float size;
    private float squareSize;

    public TerrainInfo()
    {
        resolution = 1024;
        size = 1024;
        squareSize = 1;
        MaxHeight = 512;
        Height = 10;
    }

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

    public ushort U16Height => TerrainV9Serializer.GetU16Height(Height, MaxHeight);
}
