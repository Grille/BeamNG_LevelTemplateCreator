﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTemplateCreator.SceneTree.Main;

internal class TerrainBlock : SimItem
{
    public JsonDictProperty<string> MaterialTextureSet { get; }
    public JsonDictProperty<string> TerrainFile { get; }
    public JsonDictProperty<int> BaseTexSize { get; }
    public JsonDictProperty<int> MaxHeight { get; }
    public JsonDictProperty<float> SquareSize { get; }

    public TerrainBlock(JsonDict dict) : base(dict)
    {
        MaterialTextureSet = new(this, "materialTextureSet");
        TerrainFile = new(this, "terrainFile");
        BaseTexSize = new(this, "baseTexSize");
        MaxHeight = new(this, "maxHeight");
        SquareSize = new(this, "squareSize");

        Name.Value = "theTerrain";
        Class.Value = "TerrainBlock";
    }

    public TerrainBlock(TerrainInfo info) : this(new JsonDict())
    {
        int offset = (int)info.WorldSize / 2;
        Position.Value = new System.Numerics.Vector3(-offset, -offset, 0);
        MaxHeight.Value = info.MaxHeight;
        SquareSize.Value = info.SquareSize;
    }
}