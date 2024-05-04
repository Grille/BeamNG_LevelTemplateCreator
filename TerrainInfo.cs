using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTemplateCreator;

internal class TerrainInfo
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

    public int MaxHeight { get; set; }
}
