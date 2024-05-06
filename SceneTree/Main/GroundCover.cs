using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTemplateCreator.SceneTree.Main;

internal class GroundCover : SimItem
{
    public const string ClassName = "GroundCover_Definition";

    public JsonDictProperty<string> Material { get; }

    public GroundCover(JsonDict dict) : base(dict)
    {
        Material = new(this, "material");
    }

    public void AddInstance(GroundCoverInstance instance)
    {

    }
}
