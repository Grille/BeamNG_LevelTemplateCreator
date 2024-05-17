using Grille.BeamNG.IO.Binary;
using Grille.BeamNG.SceneTree.Main;

/* Unmerged change from project 'Grille.BeamNG.Lib (net8)'
Before:
using System.Linq;
After:
using Grille.BeamNG.Terrain;
using System.Linq;
*/
using Grille.BeamNG;
using System.Linq;

namespace Grille.BeamNG;

/// <summary>Abstract lightweight representation of terrain properties, useful to generate blank terrain files.</summary>
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

    public Terrain ToTerrain()
    {
        var terrain = new Terrain(Resolution, MaterialNames.ToArray());
        var terrainData = terrain.Data;
        for (int i = 0; i < terrainData.Length; i++)
        {
            terrainData[i].Height = Height;
        }
        return terrain;
    }

    public TerrainBlock ToJsonTerrainBlock()
    {
        var block = new TerrainBlock(this);
        return block;
    }

    public void Save(string filePath)
    {
        using var stream = File.Create(filePath);
        Serialize(stream);
    }

    public void Serialize(Stream stream)
    {
        TerrainV9Serializer.Serialize(stream, this);
    }
}
