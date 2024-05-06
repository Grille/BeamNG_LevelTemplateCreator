using LevelTemplateCreator.SceneTree;
using LevelTemplateCreator.SceneTree.Art;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTemplateCreator.Assets;

abstract class MaterialAsset : Asset
{
    public Material Material { get; }

    protected MaterialAsset(JsonDictWrapper obj, string source, Material material) : base(obj, source)
    {
        Material = material;
    }
}
