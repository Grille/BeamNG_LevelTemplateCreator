using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTemplateCreator.SceneTree;

internal class TerrainBlock : SimItem
{
    public string MaterialTextureSet { get => (string)this["materialTextureSet"]; set => this["materialTextureSet"] = value; }
    public string TerrainFile { get => (string)this["terrainFile"]; set => this["terrainFile"] = value; }
    public int BaseTexSize { get => (int)this["baseTexSize"]; set => this["baseTexSize"] = value; }
    public int MaxHeight { get => (int)this["maxHeight"]; set => this["maxHeight"] = value; }
    public float SquareSize { get => (float)this["squareSize"]; set => this["squareSize"] = value; }

    public TerrainBlock()
    {
        Name = "theTerrain";
        Class = "TerrainBlock";
    }

    public TerrainBlock(TerrainInfo info) : this()
    {
        int offset = (int)info.WorldSize / 2;
        Position = new System.Numerics.Vector3(-offset, -offset, 0);
        MaxHeight = info.MaxHeight;
        SquareSize = info.SquareSize;
    }
}
