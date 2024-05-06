using LevelTemplateCreator.SceneTree;
using LevelTemplateCreator.SceneTree.Art;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTemplateCreator.Assets;

internal class ObjectPbrMaterialAsset : MaterialAsset
{
    public const string ClassName = "Material";

    public new ObjectMaterial Material => (ObjectMaterial)base.Material;

    public ObjectPbrMaterialAsset(JsonDictWrapper item, string source) : base(item, source, new ObjectMaterial(item.Dict))
    {
        //Material = new ObjectMaterial(item.Dict);
    }
}
