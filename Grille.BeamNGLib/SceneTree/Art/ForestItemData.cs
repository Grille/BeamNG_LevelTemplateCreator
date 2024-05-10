namespace Grille.BeamNgLib.SceneTree.Art;

public sealed class ForestItemData : ArtItem
{
    public const string ClassName = "TSForestItemData";

    public JsonDictProperty<string> ShapeFile { get; }

    public ForestItemData(JsonDict dict) : base(dict, ClassName)
    {
        ShapeFile = new(this, "shapeFile");
    }
}
