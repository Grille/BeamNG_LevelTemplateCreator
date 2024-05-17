
/* Unmerged change from project 'Grille.BeamNG.Lib (net8)'
Before:
using Grille.BeamNG.IO.Binary;
using System.Collections;
After:
using Grille;
using Grille.BeamNG;
using Grille.BeamNG.IO.Binary;
using Grille.BeamNG.Terrain;
using System.Collections;
*/

/* Unmerged change from project 'Grille.BeamNG.Lib (net8)'
Before:
using Grille.BeamNG.IO.Binary;
After:
using Grille;
using Grille.BeamNG.IO.Binary;
*/
using Grille.BeamNG.IO.Binary;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Grille.BeamNG;

/// <summary>
/// Abstract Representation of an full BeamNG terrain, allows full access to all terrain properties.
/// </summary>
public class Terrain
{
    public TerrainDataBuffer Data { get; set; }

    public string[] MaterialNames { get; set; }

    public int Width => Data.Width;

    public int Height => Data.Height;

    /// <summary>
    /// Are <see cref="Width"/> and <see cref="Height"/> equal?
    /// </summary>
    public bool IsSquare => Width == Height;

    /// <summary>
    /// Gets value of <see cref="Width"/> and <see cref="Height"/>, throws <see cref="InvalidOperationException"/> if <see cref="IsSquare"/> is <see langword="false"/>.
    /// </summary>
    /// <remarks>
    /// Terrain in BeamNG can only be square at the moment but should that change in the future, code using <see cref="Size"/> will no longer work.
    /// </remarks>
    public int Size
    {
        get
        {
            if (!IsSquare)
                throw new InvalidOperationException("Terrain must be square.");

            return Width;
        }
    }

    public Terrain(string path, float maxHeight = 1)
    {
        Data = null!;
        MaterialNames = null!;
        Load(path, maxHeight);
    }

    public Terrain(Stream stream, float maxHeight = 1)
    {
        Data = null!; 
        MaterialNames = null!;
        Deserialize(stream, maxHeight);
    }

    public Terrain(int size) : this(size, size) { }

    public Terrain(int size, IList<string> materialNames) : this(size, size, materialNames) { }

    public Terrain(int size, IList<string> materialNames, TerrainData[] data) : this(size, size, materialNames, data) { }

    public Terrain(int width, int height) : this(width, height, Array.Empty<string>()) { }

    public Terrain(int width, int height, IList<string> materialNames) : this(width, height, materialNames, new TerrainData[width * height]) { }

    public Terrain(int width, int height, IList<string> materialNames, TerrainData[] data)
    {
        Data = new TerrainDataBuffer(width, height, data);
        MaterialNames = materialNames.ToArray();
    }

    public void Load(string path, float maxHeight = 1)
    {
        using var stream = File.OpenRead(path);
        Deserialize(stream, maxHeight);
    }

    public void Save(string path, float maxHeight = 1)
    {
        using var stream = File.Create(path);
        Serialize(stream, maxHeight);
    }

    public void Serialize(Stream stream, float maxHeight = 1)
    {
        TerrainSerializer.Serialize(stream, this, maxHeight);
    }

    public void Deserialize(Stream stream, float maxHeight = 1)
    {
        TerrainSerializer.Deserialize(stream, this, maxHeight);
    }

    public Terrain Clone()
    {
        var terrain = new Terrain(Size, MaterialNames.ToArray());
        Data.CopyTo(terrain.Data);
        return terrain;
    }

    public Terrain Resize(int size)
    {
        return Resize(size, size);
    }

    public Terrain Resize(int width, int height)
    {
        var names = new string[MaterialNames.Length];
        MaterialNames.CopyTo(names, 0);
        var terrain = new Terrain(width, names);

        var src = new Rectangle(Point.Empty, new Size(Width, Height));
        var dst = new Rectangle(Point.Empty, new Size(width, height));
        terrain.Draw(this, dst, src);

        return terrain;
    }

    public void Draw(Terrain terrain, Point position)
    {
        var size = new Size(terrain.Width, terrain.Height);
        var src = new Rectangle(Point.Empty, size);
        var dst = new Rectangle(position, size);
        Draw(terrain, dst, src);
    }

    public void Draw(Terrain terrain, Rectangle dstRect, Rectangle srcRect)
    {
        float srcOffsetX = srcRect.X / terrain.Width;
        float srcOffsetY = srcRect.Y / terrain.Height;

        float srcScaleX = srcRect.Width / terrain.Width;
        float srcScaleY = srcRect.Height / terrain.Width;

        for (int iy = 0; iy < dstRect.Height; iy++)
        {
            int dstY = iy + dstRect.Y;
            float srcY = srcOffsetY + iy * srcScaleY;
            for (int ix = 0; ix < dstRect.Width; ix++)
            {
                int dstX = ix + dstRect.X;
                float srcX = srcOffsetX + ix * srcScaleX;

                if (dstX < 0 || dstY < 0 || dstX > Width || dstY > Height)
                    continue;

                Data[dstX, dstY] = terrain.Data.Sample(srcX, srcY);
            }
        }
    }

    public void Draw(TerrainData data, Rectangle dstRect)
    {
        for (int iy = 0; iy < dstRect.Height; iy++)
        {
            int dstY = iy + dstRect.Y;
            for (int ix = 0; ix < dstRect.Width; ix++)
            {
                int dstX = ix + dstRect.X;

                if (dstX < 0 || dstY < 0 || dstX > Width || dstY > Height)
                    continue;

                Data[dstX, dstY] = data;
            }
        }
    }
}