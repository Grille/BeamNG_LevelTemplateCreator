using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTemplateCreator.SceneTree.Main;

internal class GroundCoverDefinition : SimItem
{
    public const string ClassName = "GroundCover_Definition";

    public GroundCoverDefinition(JsonDict dict) : base(dict)
    {
    }
}
