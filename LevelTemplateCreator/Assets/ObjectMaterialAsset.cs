using Grille.BeamNgLib.SceneTree.Art;
using static System.Windows.Forms.AxHost;


namespace LevelTemplateCreator.Assets;

public class ObjectMaterialAsset : MaterialAsset<ObjectMaterial>
{
    public const string ClassName = ObjectMaterial.ClassName;

    public ObjectMaterialAsset(ObjectMaterial item, AssetSource info) : base(item, info)
    {
        //Material = new ObjectMaterial(item.Dict);
    }

    public override ObjectMaterial GetCopy()
    {
        var clone = new JsonDict(Object.Dict);
        var stages = new JsonDict[4] { new(Object.Stage0.Dict), new(Object.Stage1.Dict), new(Object.Stage2.Dict), new(Object.Stage3.Dict) };
        clone["Stages"] = stages;

        return new ObjectMaterial(clone);
    }
}
