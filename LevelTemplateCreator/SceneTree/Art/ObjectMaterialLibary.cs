using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTemplateCreator.SceneTree.Art;

internal class ObjectMaterialLibary : MaterialLibary<ObjectMaterial>
{
    public ObjectMaterialLibary(string path) : base(path)
    {
    }

    public override void AddAsset<TAsset>(TAsset asset)
    {
        var copy = asset.GetCopy();
        copy.ResolveTexturePaths(this, asset.SourceFile);
        Materials.Add(copy);
    }
}
