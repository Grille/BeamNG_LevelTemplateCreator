using Grille.BeamNG.SceneTree.Art;


namespace LevelTemplateCreator.Assets;

public abstract class MaterialAsset<T> : Asset<T> where T : Material
{
    public T Material => Object;

    protected MaterialAsset(T obj, AssetSource info) : base(obj, info)
    {  }
}
