using LevelTemplateCreator.SceneTree;
using LevelTemplateCreator.SceneTree.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTemplateCreator.Assets;

internal class GroundCoverAsset : Asset
{
    public const string ClassName = "GroundCover";

    public GroundCoverDefinition Definition { get; }

    public GroundCoverAsset(JsonDictWrapper item, string file) : base(item, file)
    {
        Definition = new GroundCoverDefinition(item.Dict);
    }
}
