using System.Drawing;

namespace Grille.BeamNG.IO.Binary;

public class TerrainV9Binary
{
    public byte Version { get; set; }
     
    public int Size { get; set; }

    public ushort[] HeightData { get; set; }

    public byte[] MaterialData { get; set; }

    public string[] MaterialNames { get; set; }

    public int Length => Size * Size;

    public TerrainV9Binary()
    {
        Version = 9;
        Size = 0;

        HeightData = Array.Empty<ushort>();
        MaterialData = Array.Empty<byte>();
        MaterialNames = Array.Empty<string>();
    }

    public TerrainV9Binary(int size)  {
        Version = 9;
        Size = size;
        var length = Length;
        HeightData = new ushort[length];
        MaterialData = new byte[length];
        MaterialNames = Array.Empty<string>();
    }
}