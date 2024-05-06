using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTemplateCreator.SceneTree.Main;

internal class GroundCoverInstance : SimItem
{
    public const string ClassName = "GroundCover_Instance";

    public GroundCoverInstance(JsonDict dict) : base(dict)
    {
    }
}
