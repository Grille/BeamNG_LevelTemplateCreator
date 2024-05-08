using LevelTemplateCreator.SceneTree;
using LevelTemplateCreator.SceneTree.Art;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTemplateCreator.Assets;

abstract class MaterialAsset<T> : Asset<T> where T : Material
{
    public T Material => Object;

    protected MaterialAsset(T obj, AssetCreateInfo info) : base(obj, info)
    {  }
}
