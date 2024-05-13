using Grille.BeamNG.IO;
using Grille.BeamNG.IO.Binary;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace Grille.BeamNG;

public class Terrain
{
    public struct TerrainData
    {
        public float Height;
        public int Material;
        public bool IsHole;

        public override string ToString()
        {
            return $"Height: {Height} Material: {Material} IsHole: {IsHole}";
        }
    }

    public class TerrainDataBuffer : IReadOnlyCollection<TerrainData>
    {
        public TerrainData[] _data { get; }

        public int Width { get; }

        public int Height { get; }

        public int Length { get; }

        public TerrainDataBuffer(int width, int height, TerrainData[] data)
        {
            Width = width;
            Height = height;
            Length = width * height;

            if (data.Length != Length)
            {
                throw new ArgumentException($"data.Length must be Size^2 == {Length}", nameof(data));
            }

            _data = data;
        }

        public TerrainDataBuffer(int width, int height)
        {
            Width = width;
            Height = height;
            Length = width * height;
            _data = new TerrainData[Length];
        }

        public ref TerrainData this[int index] => ref _data[index];

        public ref TerrainData this[int x, int y] => ref _data[y * Width + x];

        int IReadOnlyCollection<TerrainData>.Count => _data.Length;

        public IEnumerator<TerrainData> GetEnumerator() => ((IEnumerable<TerrainData>)_data).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _data.GetEnumerator();
    }

    public int Size { get; private set; }

    public TerrainDataBuffer Data { get; private set; }

    public string[] MaterialNames { get; set; }

    public Terrain(string path, float maxHeight) {
        Load(path, maxHeight);
    }

    public Terrain(Stream stream, float maxHeight)
    {
        Deserialize(stream, maxHeight);
    }

    public Terrain() : this(0) { }

    public Terrain(int size) : this(size, Array.Empty<string>()) { }

    public Terrain(int size, string[] materialNames) : this(size, materialNames, new TerrainData[size * size]) { }

    public Terrain(int size, string[] materialNames, TerrainData[] data)
    {
        Size = size;
        Data = new TerrainDataBuffer(size, size, data);
        MaterialNames = materialNames;
    }

    [MemberNotNull(nameof(Data), nameof(MaterialNames))]
    public void Load(string path, float maxHeight)
    {
        using var stream = File.OpenRead(path);
        Deserialize(stream, maxHeight);
    }

    public void Save(string path, float maxHeight)
    {
        using var stream = File.Create(path);
        Serialize(stream, maxHeight);
    }

    public void Serialize(Stream stream, float maxHeight)
    {
        var binary = new TerrainV9Binary(Size);
        Serialize(binary, maxHeight);
        TerrainV9Serializer.Serialize(stream, binary);
    }

    [MemberNotNull(nameof(Data), nameof(MaterialNames))]
    public void Deserialize(Stream stream, float maxHeight)
    {
        var binary = TerrainV9Serializer.Deserialize(stream);
        Deserialize(binary, maxHeight);
    }

    public void Serialize(TerrainV9Binary binary, float maxHeight)
    {
        int length = Data.Length;
        for (int i = 0; i< length; i++)
        {
            ref var data = ref Data[i];
            ushort u16height = TerrainV9Serializer.GetU16Height(data.Height, maxHeight);
            binary.HeightData[i] = u16height;
            binary.MaterialData[i] = data.IsHole ? byte.MaxValue : (byte)data.Material;
        }
    }

    [MemberNotNull(nameof(Data), nameof(MaterialNames))]
    public void Deserialize(TerrainV9Binary binary, float maxHeight)
    {
        Resize(binary.Size);
        int length = Data.Length;

        for (int i = 0; i < length; i++)
        {
            ref var data = ref Data[i];
            ushort u16height = binary.HeightData[i];
            byte material = binary.MaterialData[i];
            data.Height = TerrainV9Serializer.GetSingleHeight(u16height, maxHeight);

            if (material == byte.MaxValue)
            {
                data.Material = 0;
                data.IsHole = true;
            }
            else
            {
                data.Material = material;
                data.IsHole = false;
            }
        }

        MaterialNames = binary.MaterialNames;
    }

    [MemberNotNull(nameof(Data))]
    public void Resize(int size)
    {
        if (Size != size || Data == null)
        {
            Size = size;
            Data = new TerrainDataBuffer(size, size);
        }
    }
}