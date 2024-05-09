namespace Grille.BeamNgLib.SceneTree.Main;

public class SimItem : JsonDictWrapper
{
    public JsonDictProperty<Vector3> Position { get; }

    public JsonDictProperty<string> Parent { get; }

    public SimItem(JsonDict dict) : base(dict)
    {
        Position = new(this, "position");
        Parent = new(this, "__parent");
    }

    public void SetParent(SimGroup? parent)
    {
        if (parent == null)
        {
            Parent.Remove();
            return;
        }

        Parent.Value = parent.Name.Value;
    }
}
