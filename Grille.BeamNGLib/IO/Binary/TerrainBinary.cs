namespace Grille.BeamNgLib.IO.Binary;

public class TerrainBinary
{
    public struct TerrainData
    {
        public ushort Height;
        public byte Material;

        public bool IsHole => Material == byte.MaxValue;

        public void SetHeight(float value, float maxHeight) => Height = TerrainV9Serializer.GetU16Height(value, maxHeight);
        public float GetHeight(float maxHeight) => TerrainV9Serializer.GetSingleHeight(Height, maxHeight);
    }

    public int Size { get; }

    public TerrainData[] Data { get; }

    public string[] MaterialNames { get; set; }

    public int TotalSize => Size * Size;

    public TerrainBinary(int size) : this(size, Array.Empty<string>()) { }

    public TerrainBinary(int size, string[] materialNames) : this(size, materialNames, new TerrainData[size * size]) { }

    public TerrainBinary(int size, string[] materialNames, TerrainData[] data)
    {
        Size = size;
        Data = data;
        MaterialNames = materialNames;

        if (data.Length != TotalSize)
        {
            throw new ArgumentException($"data.Length must be {TotalSize}", nameof(data));
        }
    }
}