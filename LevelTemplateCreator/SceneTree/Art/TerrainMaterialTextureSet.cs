using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace LevelTemplateCreator.SceneTree.Art;

internal class TerrainMaterialTextureSet : JsonDictWrapper
{
    public JsonDictProperty<Vector2> BaseTexSize { get; }
    public JsonDictProperty<Vector2> DetailTexSize { get; }
    public JsonDictProperty<Vector2> MacroTexSize { get; }

    public TerrainMaterialTextureSet(string name) : base(new JsonDict())
    {
        Class.Value = "TerrainMaterialTextureSet";
        Name.Value = name;

        BaseTexSize = new(this, "baseTexSize");
        DetailTexSize = new(this, "detailTexSize");
        MacroTexSize = new(this, "macroTexSize");

        BaseTexSize.Value = new Vector2(1024, 1024);
        DetailTexSize.Value = new Vector2(1024, 1024);
        MacroTexSize.Value = new Vector2(1024, 1024);
    }
}
