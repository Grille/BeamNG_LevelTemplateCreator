namespace Grille.BeamNgLib.SceneTree.Art;

public sealed class ForestItemData : JsonDictWrapper
{
    public const string ClassName = "TSForestItemData";

    public JsonDictProperty<string> ShapeFile { get; }

    public ForestItemData(JsonDict dict) : base(dict)
    {
        ShapeFile = new(this, "shapeFile");
    }
}
