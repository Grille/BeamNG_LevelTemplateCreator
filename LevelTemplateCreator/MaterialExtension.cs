using Grille.BeamNgLib.IO.Resources;
using Grille.BeamNgLib.SceneTree.Art;
using LevelTemplateCreator.Assets;
using LevelTemplateCreator.IO.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTemplateCreator;
internal static class MaterialExtension
{
    public static void EvalPathExpressions(this Material material, Asset asset, string path, ResourceCollection textures)
    {
        foreach (var texture in material.EnumerateTexturePaths())
        {
            var resource = PathExpressionEvaluator.Get(texture.Value, asset.Info);
            textures.Add(resource);
            texture.Value = Path.Combine(path, resource.DynamicName);
        }
    }
}
