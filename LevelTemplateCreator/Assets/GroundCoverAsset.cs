using LevelTemplateCreator.SceneTree;
using LevelTemplateCreator.SceneTree.Main;

namespace LevelTemplateCreator.Assets;

internal class GroundCoverAsset : Asset<GroundCover>
{
    public const string ClassName = GroundCover.ClassName;

    public GroundCover GroundCover => Object;

    public GroundCoverAsset(GroundCover item, AssetInfo info) : base(item, info) { }
}
