namespace Grille.BeamNgLib.SceneTree.Main;

public class GroundCover : SimItem
{
    public const string ClassName = "GroundCover";

    public JsonDictProperty<string> Material { get; }

    public JsonDictProperty<JsonDict[]> Types { get; }

    public GroundCover(JsonDict dict) : base(dict)
    {
        Material = new(this, "material");

        Types = new(this, "Types");
    }

    public void AddInstance(GroundCoverInstance instance)
    {

    }

    public override void ApplyPrefix(string prefix)
    {
        base.ApplyPrefix(prefix);

        Material.Value = prefix + Material.Value;
    }
}
