using LevelTemplateCreator.SceneTree;
using LevelTemplateCreator.SceneTree.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTemplateCreator.Assets;

internal class GroundCoverInstanceAsset : Asset
{
    public GroundCoverInstance Instance { get; }

    public GroundCoverInstanceAsset(JsonDictWrapper obj, string source) : base(obj, source)
    {
        Instance = new GroundCoverInstance(obj.Dict);
    }
}
