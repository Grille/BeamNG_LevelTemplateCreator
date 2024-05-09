using Grille.BeamNgLib.SceneTree.Art;
using LevelTemplateCreator.IO.Resources;

namespace LevelTemplateCreator.Assets;

public class TerrainMaterialAsset : MaterialAsset<TerrainMaterial>
{
    public const string ClassName = TerrainMaterial.ClassName;

    public float SquareSize { get; }

    public TerrainMaterialAsset(TerrainMaterial item, AssetSource info) : base(item, info)
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

    public override TerrainMaterial GetCopy()
    {
        var dict = new JsonDict(Object.Dict);
        return new TerrainMaterial(dict);
    }
}
