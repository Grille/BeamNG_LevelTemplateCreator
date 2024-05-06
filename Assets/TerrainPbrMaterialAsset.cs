using LevelTemplateCreator.SceneTree;
using LevelTemplateCreator.SceneTree.Art;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTemplateCreator.Assets;

internal class TerrainPbrMaterialAsset : MaterialAsset
{
    public const string ClassName = "TerrainMaterial";


    public new TerrainPbrMaterial Material => (TerrainPbrMaterial)base.Material;

    public float SquareSize { get; }

    public TerrainPbrMaterialAsset(JsonDictWrapper item, string file) : base(item, file, new TerrainPbrMaterial(item.Dict))
    {
        Material.TryPopValue("squareSize", out float squareSize, 1);
        SquareSize = squareSize;

        if (!Material.InternalName.Exists)
        {
            Material.InternalName.Value = Material.Name.Value;
        }

        Material.CreatePersistentId();

        Name = Material.InternalName.Value;

        /*
        if (material.TryPopValue("groundcover", out Dictionary<string, object>[] groundcover))
        {

        }
        */

        SetLayerIfEmpty(Material.AmbientOcclusion.Base, "#ffffff");
        SetLayerIfEmpty(Material.Normal.Base, "#7f7fff");
        SetLayerIfEmpty(Material.Height.Base, "#000000");
        SetLayerIfEmpty(Material.BaseColor.Base, "#515151");
    }

    void SetLayerIfEmpty(TerrainMaterialTextureLayer layer, string value)
    {
        if (layer.IsTextureEmpty)
        {
            layer.Texture.Value = value;
        }
    }
}
