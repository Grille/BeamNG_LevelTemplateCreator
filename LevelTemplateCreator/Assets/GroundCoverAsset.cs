using Grille.BeamNgLib.SceneTree.Main;

namespace LevelTemplateCreator.Assets;

public class GroundCoverAsset : Asset<GroundCover>
{
    public const string ClassName = GroundCover.ClassName;

    public GroundCover GroundCover => Object;

    public GroundCoverAsset(GroundCover item, AssetSource info) : base(item, info) { }

    public override GroundCover GetCopy()
    {
        var dict = Object.Dict;
        return new GroundCover(dict);
    }
}
