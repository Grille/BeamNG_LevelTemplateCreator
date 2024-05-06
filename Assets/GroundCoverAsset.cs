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

    public GroundCover GroundCover { get; }

    public GroundCoverAsset(JsonDictWrapper item, string file) : base(item, file)
    {
        GroundCover = new GroundCover(item.Dict);
    }

    public void CreateNew(AssetCollection<GroundCoverInstanceAsset> instances)
    {

    }
}
