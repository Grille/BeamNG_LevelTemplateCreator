using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTemplateCreator.SceneTree.Art;

internal class ForestItemData : JsonDictWrapper
{
    public const string ClassName = "TSForestItemData";

    public JsonDictProperty<string> ShapeFile { get; }

    public ForestItemData(JsonDict dict) : base(dict)
    {
        ShapeFile = new(this, "shapeFile");
    }
}
