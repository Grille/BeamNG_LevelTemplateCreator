using Grille.BeamNG.SceneTree.Art;
using LevelTemplateCreator.Assets;
using LevelTemplateCreator.IO.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace LevelTemplateCreator.GUI;
public static class TexturePackPrimer
{
    public static void Open(AssetLibary libary, string @namespace)
    {
        var materials = new List<TerrainMaterialAsset>();

        foreach (var asset in libary.TerrainMaterials)
        {
            if (asset.Namespace == @namespace)
                materials.Add(asset);
        }

        var sb = new StringBuilder();

        void WriteVar(string key, string value)
        {
            sb.AppendLine($"{key} {value}");
        }

        void WriteUsing(string name)
        {
            sb.AppendLine($"Using({name})");
        }

        void WriteOverride(string key, string value)
        {
            sb.AppendLine($"Set({key}, {value})");
        }

        var baseAmbientOcclusion = "$BaseAmbientOcclusion";
        var baseColor = $"$BaseColor";
        var baseHeight = "$BaseHeight";
        var baseNormal = "$BaseNormal";
        var baseRoughness = $"$BaseRoughness";

        WriteVar(baseAmbientOcclusion, SolidColorNames.BaseAmbientOcclusion);
        WriteVar(baseColor, SolidColorNames.BaseColor);
        WriteVar(baseHeight, SolidColorNames.BaseHeight);
        WriteVar(baseNormal, SolidColorNames.BaseNormal);
        WriteVar(baseRoughness, SolidColorNames.BaseRoughness);
        sb.AppendLine();

        foreach (var material in materials)
        {
            WriteUsing(material.OriginalName);
            WriteOverride(material.Material.AmbientOcclusion.Base.Texture.Key, baseAmbientOcclusion);
            WriteOverride(material.Material.BaseColor.Base.Texture.Key, baseColor);
            WriteOverride(material.Material.Height.Base.Texture.Key, baseHeight);
            WriteOverride(material.Material.Normal.Base.Texture.Key, baseNormal);
            WriteOverride(material.Material.Roughness.Base.Texture.Key, baseRoughness);
            sb.AppendLine();
        }

        File.WriteAllText($"{@namespace}out_terrain_materials.cfg", sb.ToString());
    }
}
