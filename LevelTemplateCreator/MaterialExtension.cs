using Grille.BeamNG.IO.Resources;
using Grille.BeamNG.SceneTree.Art;
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
    public static void EvalPathExpressions(this Material material, Asset asset, string path, ResourceCollection textures, FileCopyMode mode)
    {
        if (mode == FileCopyMode.None)
            return;

        foreach (var texture in material.EnumerateTexturePaths())
        {
            var resource = PathExpressionEvaluator.Get(texture.Value, asset.Info);
            if (mode == FileCopyMode.Local && resource.IsGameResource)
                continue;
            textures.Add(resource);
            texture.Value = Path.Combine(path, Path.GetFileNameWithoutExtension( resource.Name));
        }
    }
}
