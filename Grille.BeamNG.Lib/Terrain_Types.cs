using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grille.BeamNG;

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
    readonly TerrainData[] _data;

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

    public TerrainData Sample(float x, float y)
    {
        int ix = (int)(x * Width + 0.5) % Width;
        int iy = (int)(y * Height + 0.5) % Height;
        if (ix < 0) ix = Width + ix;
        if (iy < 0) iy = Height + iy;

        return this[ix, iy];
    }

    public void CopyTo(TerrainDataBuffer data)
    {
        _data.CopyTo(data._data, 0);
    }

    public ref TerrainData this[int index] => ref _data[index];

    public ref TerrainData this[int x, int y] => ref _data[y * Width + x];

    int IReadOnlyCollection<TerrainData>.Count => _data.Length;

    public IEnumerator<TerrainData> GetEnumerator() => ((IEnumerable<TerrainData>)_data).GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => _data.GetEnumerator();
}


