using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace LevelTemplateCreator.SceneTree;

internal class TerrainMaterialTextureSet : SimItem
{
    public TerrainMaterialTextureSet(string name)
    {
        Class = "TerrainMaterialTextureSet";
        Name = name;

        SetVec2("baseTexSize", new Vector2(1024, 1024));
        SetVec2("detailTexSize", new Vector2(1024, 1024));
        SetVec2("macroTexSize", new Vector2(1024, 1024));
    }
}
