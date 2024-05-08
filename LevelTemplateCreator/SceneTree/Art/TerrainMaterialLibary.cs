using LevelTemplateCreator.Assets;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTemplateCreator.SceneTree.Art;

internal class TerrainMaterialLibary : MaterialLibary<TerrainMaterial>
{
    readonly float _squareSize;

    public TerrainMaterialLibary(string path, float squareSize) : base(path)
    {
        _squareSize = squareSize;
    }

    public override void AddAsset<TAsset>(TAsset asset)
    {
        float squareSize = asset switch
        {
            TerrainMaterialAsset tma => tma.SquareSize,
            _ => 1
        };

        var copy = asset.GetCopy();
        copy.CreatePersistentId();
        copy.MultiplyMappingScale(squareSize / _squareSize);
        copy.ResolveTexturePaths(this, asset.Info);
        Materials.Add(copy);
    }

    public void CreateTerrainMaterialTextureSet(string name)
    {
        Misc.Add(new TerrainMaterialTextureSet(name));
    }
}
