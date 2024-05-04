using LevelTemplateCreator.SceneTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTemplateCreator.Assets;

internal class TerrainMaterialAsset : Asset
{
    public const string ClassName = "TerrainMaterial";

    public TerrainMaterial Material { get; }

    public float SquareSize { get; }

    public TerrainMaterialAsset(SimItem item)
    {
        var dict = item.Dict;
        var material = new TerrainMaterial();
        material.Dict = dict;

        material.Class = TerrainMaterial.ClassName;

        if (material.TryPopValue("preview", out string previewPath))
            LoadPreview(previewPath);

        if (material.TryPopValue("squareSize", out float squareSize))
            SquareSize = squareSize;
        else
            SquareSize = 1;

        if (!dict.ContainsKey("internalName")){
            material.InternalName = material.Name;
        }
        material.CreatePersistentId();

        Name = material.InternalName;
        Material = material;

        SetLayerIfEmpty(material.AmbientOcclusion.Base, "#ffffff");
        SetLayerIfEmpty(material.Normal.Base, "#7f7fff");
        SetLayerIfEmpty(material.Height.Base, "#000000");
        SetLayerIfEmpty(material.BaseColor.Base, "#515151");
    }

    void SetLayerIfEmpty(TerrainMaterialTextureLayer layer, string value)
    {
        if (layer.IsEmpty)
        {
            layer.Texture = value;
        }
    }
}
