using LevelTemplateCreator.SceneTree;
using LevelTemplateCreator.SceneTree.Art;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTemplateCreator.Assets;

internal class ObjectMaterialAsset : MaterialAsset<ObjectMaterial>
{
    public const string ClassName = ObjectMaterial.ClassName;

    public ObjectMaterialAsset(ObjectMaterial item, AssetInfo info) : base(item, info)
    {
        //Material = new ObjectMaterial(item.Dict);
    }
}
