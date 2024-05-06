using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTemplateCreator.SceneTree.Main;

internal class GroundCover : SimItem
{
    public const string ClassName = "GroundCover";

    public GroundCover(JsonDict dict) : base(dict)
    {
    }
}
