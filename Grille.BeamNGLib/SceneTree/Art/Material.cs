namespace Grille.BeamNgLib.SceneTree.Art;

public abstract class Material : ArtItem
{
    protected Material(JsonDict dict) : base(dict) { }

    public abstract IEnumerable<JsonDictProperty<string>> EnumerateTexturePaths();
}
