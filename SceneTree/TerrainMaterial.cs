﻿using LevelTemplateCreator.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LevelTemplateCreator.SceneTree;
internal class TerrainMaterial : SimItem
{
    public string GroundModel { get => (string)this["groundmodelName"]; set => this["groundmodelName"] = value; }

    public TerrainMaterialTexture BaseColor { get; }
    public TerrainMaterialTexture Normal { get; }
    public TerrainMaterialTexture Roughness { get; }
    public TerrainMaterialTexture AmbientOcclusion { get; }
    public TerrainMaterialTexture Height { get; }

    public TerrainMaterialDistances MacroDistances { get; }
    public TerrainMaterialDistances DetailDistances { get; }

    public TerrainMaterial()
    {
        Class = "TerrainMaterial";

        BaseColor = new(this, "baseColor");
        Normal = new(this, "normal");
        Roughness = new(this, "roughness");
        AmbientOcclusion = new(this, "ao");
        Height = new(this, "height");

        MacroDistances = new(this, "macro", [0, 10, 100, 1000], Vector2.UnitY);
        DetailDistances = new(this, "detail", [0, 0, 50, 100], Vector2.One);
    }

    public void IndexTextures(RessourceFileManager ressources)
    {
        BaseColor.IndexTextures(ressources);
        Normal.IndexTextures(ressources); 
        Roughness.IndexTextures(ressources);
        AmbientOcclusion.IndexTextures(ressources);
        Height.IndexTextures(ressources);
    }
}

internal class TerrainMaterialDistances
{
    public string Prefix { get; }
    public TerrainMaterial Owner { get; }

    readonly string _distancesKey;
    readonly string _distAttenKey;

    public TerrainMaterialDistances(TerrainMaterial owner, string prefix, int[] distances, Vector2 vector)
    {
        Owner = owner;
        Prefix = prefix;

        if (distances.Length != 4)
            throw new ArgumentException();

        _distancesKey = prefix + "Distances";
        _distAttenKey = prefix + "DistAtten";
        Distances = distances;
        DistanceAttenuation = vector;
    }

    public int[] Distances { get => (int[])Owner[_distancesKey]; set => Owner[_distancesKey] = value; }

    public int StartFadeIn { get => Distances[0]; set => Distances[0] = value; }
    public int Near { get => Distances[1]; set => Distances[1] = value; }
    public int Far { get => Distances[2]; set => Distances[2] = value; }
    public int EndFadeOut { get => Distances[3]; set => Distances[3] = value; }

    public Vector2 DistanceAttenuation { get => Owner.GetVec2(_distAttenKey); set => Owner.SetVec2(_distAttenKey, value); }
}

internal class TerrainMaterialTexture
{
    public string Prefix { get; }
    public TerrainMaterial Owner { get; }

    public TerrainMaterialTextureLevel Base { get; }
    public TerrainMaterialTextureLevel Macro { get; }
    public TerrainMaterialTextureLevel Detail { get; }

    public TerrainMaterialTexture(TerrainMaterial owner, string prefix)
    {
        Owner = owner;
        Prefix = prefix;

        Base = new(this, "Base");
        Macro = new(this, "Macro");
        Detail = new(this, "Detail");
    }

    public void IndexTextures(RessourceFileManager ressources) {
        Base.IndexTexture(ressources);
        Macro.IndexTexture(ressources);
        Detail.IndexTexture(ressources);
    }
}

internal class TerrainMaterialTextureLevel
{
    public string Prefix { get; }
    public TerrainMaterial Owner { get; }

    readonly string _strengthKey;
    readonly string _texSizeKey;
    readonly string _texKey;

    public TerrainMaterialTextureLevel(TerrainMaterialTexture owner, string prefix)
    {
        Owner = owner.Owner;
        Prefix = owner.Prefix + prefix;

        _texKey = Prefix + "Tex";
        _texSizeKey = Prefix + "TexSize";
        _strengthKey = Prefix + "Strength";

        Strength = Vector2.One;
    }

    public string Texture { get => (string)Owner[_texKey]; set => Owner[_texKey] = value; }
    public int MappingScale { get => (int)Owner[_texSizeKey]; set => Owner[_texSizeKey] = value; }
    public Vector2 Strength { get => Owner.GetVec2(_strengthKey); set => Owner.SetVec2(_strengthKey, value); }

    public void IndexTexture(RessourceFileManager ressources)
    {
        Texture = ressources.Register(Texture);
    }
}