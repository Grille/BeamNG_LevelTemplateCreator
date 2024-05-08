using LevelTemplateCreator.IO.Resources;
using LevelTemplateCreator.SceneTree;
using LevelTemplateCreator.SceneTree.Art;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTemplateCreator.Assets;

internal class TerrainMaterialAsset : MaterialAsset<TerrainMaterial>
{
    public const string ClassName = TerrainMaterial.ClassName;

    public float SquareSize { get; }

    public TerrainMaterialAsset(TerrainMaterial item, AssetInfo info) : base(item, info)
    {
        Material.TryPopValue("squareSize", out float squareSize, 1);
        SquareSize = squareSize;

        if (!Material.InternalName.Exists)
        {
            Material.InternalName.Value = Material.Name.Value;
        }

        SetLayerIfEmpty(Material.AmbientOcclusion.Base, SolidColorNames.BaseAmbientOcclusion);
        SetLayerIfEmpty(Material.Normal.Base, SolidColorNames.BaseNormal);
        SetLayerIfEmpty(Material.Height.Base, SolidColorNames.BaseHeight);
        SetLayerIfEmpty(Material.BaseColor.Base, SolidColorNames.BaseColor);
        SetLayerIfEmpty(Material.Roughness.Base, SolidColorNames.BaseRoughness);
    }

    void SetLayerIfEmpty(TerrainMaterialTextureLayer layer, string value)
    {
        if (layer.IsTextureEmpty)
        {
            layer.Texture.Value = value;
        }
    }
}
