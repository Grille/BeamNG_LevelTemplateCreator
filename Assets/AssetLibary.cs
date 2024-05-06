using LevelTemplateCreator.IO;
using LevelTemplateCreator.IO.Resources;
using LevelTemplateCreator.SceneTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LevelTemplateCreator.Assets;

internal class AssetLibary
{
    public List<LevelPreset> LevelPresets { get; }

    public ResourceManager TextureFiles { get; }

    public List<TerrainPbrMaterialAsset> TerrainMaterials { get; }

    public List<ObjectPbrMaterialAsset> ObjectMaterials { get; }

    public List<GroundCoverAsset> GroundCoverAssets { get; }

    public Bitmap? Preview { get; set; }

    public AssetLibary()
    {
        LevelPresets = new();
        TextureFiles = new();
        TerrainMaterials = new();
        ObjectMaterials = new();
        GroundCoverAssets = new();
    }
}
