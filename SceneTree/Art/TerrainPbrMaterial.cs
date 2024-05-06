using LevelTemplateCreator.Assets;
using LevelTemplateCreator.IO.Resources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LevelTemplateCreator.SceneTree.Art;
internal class TerrainPbrMaterial : Material
{
    public const string ClassName = "TerrainMaterial";

    public JsonDictProperty<string> GroundModel { get; }

    public TerrainMaterialTexture BaseColor { get; }
    public TerrainMaterialTexture Normal { get; }
    public TerrainMaterialTexture Roughness { get; }
    public TerrainMaterialTexture AmbientOcclusion { get; }
    public TerrainMaterialTexture Height { get; }

    public TerrainMaterialDistances MacroDistances { get; }
    public TerrainMaterialDistances DetailDistances { get; }

    public ReadOnlyCollection<TerrainMaterialTextureLayer> Levels { get; }

    public TerrainPbrMaterial(JsonDict dict) : base(dict)
    {
        GroundModel = new(this, "groundmodelName");

        BaseColor = new(this, "baseColor");
        Normal = new(this, "normal");
        Roughness = new(this, "roughness");
        AmbientOcclusion = new(this, "ao");
        Height = new(this, "height");

        MacroDistances = new(this, "macro", [0, 10, 100, 1000], Vector2.UnitY);
        DetailDistances = new(this, "detail", [0, 0, 50, 100], Vector2.One);

        Levels = new ReadOnlyCollection<TerrainMaterialTextureLayer>([
            BaseColor.Base, BaseColor.Macro, BaseColor.Detail,
            Normal.Base, Normal.Macro, Normal.Detail,
            Roughness.Base, Roughness.Macro, Roughness.Detail,
            AmbientOcclusion.Base, AmbientOcclusion.Macro, AmbientOcclusion.Detail,
            Height.Base, Height.Macro, Height.Detail,
        ]);
    }

    public void NormalizeSquareSize(float squareSize)
    {

    }

    public void CreatePersistentId()
    {
        PersistentId.Value = "id";
        Name.Value = $"{InternalName}_{PersistentId}";
    }

    public override void ResolveTexturePaths(MaterialLibary libary, string source)
    {
        foreach (var level in Levels)
        {
            if (level.IsTextureEmpty) 
                continue;
            var key = libary.Textures.Register(level.Texture.Value, source);
            level.Texture.Value = Path.Combine(libary.TexturesPath, key);
        }
    }

    public override Material Copy()
    {
        var copy = new JsonDict(Dict);
        return new TerrainPbrMaterial(copy);
    }
}

internal class TerrainMaterialDistances
{
    public string Prefix { get; }
    public TerrainPbrMaterial Owner { get; }

    public JsonDictProperty<float[]> Distances { get; }
    public JsonDictProperty<Vector2> DistanceAttenuation { get; }

    public TerrainMaterialDistances(TerrainPbrMaterial owner, string prefix, float[] distances, Vector2 vector)
    {
        Owner = owner;
        Prefix = prefix;

        if (distances.Length != 4)
            throw new ArgumentException();

        var distancesKey = prefix + "Distances";
        var distAttenKey = prefix + "DistAtten";

        Distances = new(Owner, distancesKey);
        DistanceAttenuation = new(Owner, distAttenKey);

        Distances.SetIfEmpty(distances);
        DistanceAttenuation.SetIfEmpty(vector);
    }

    public int StartFadeIn { get => (int)Distances.Value[0]; set => Distances.Value[0] = value; }
    public int Near { get => (int)Distances.Value[1]; set => Distances.Value[1] = value; }
    public int Far { get => (int)Distances.Value[2]; set => Distances.Value[2] = value; }
    public int EndFadeOut { get => (int)Distances.Value[3]; set => Distances.Value[3] = value; }
}

internal class TerrainMaterialTexture
{
    public string Prefix { get; }
    public TerrainPbrMaterial Owner { get; }

    public TerrainMaterialTextureLayer Base { get; }
    public TerrainMaterialTextureLayer Macro { get; }
    public TerrainMaterialTextureLayer Detail { get; }

    public TerrainMaterialTexture(TerrainPbrMaterial owner, string prefix)
    {
        Owner = owner;
        Prefix = prefix;

        Base = new(this, "Base");
        Macro = new(this, "Macro");
        Detail = new(this, "Detail");
    }
}

internal class TerrainMaterialTextureLayer
{
    public string Prefix { get; }
    public TerrainPbrMaterial Owner { get; }

    public JsonDictProperty<Vector2> Strength { get; }
    public JsonDictProperty<int> MappingScale { get; }
    public JsonDictProperty<string> Texture { get; }

    public TerrainMaterialTextureLayer(TerrainMaterialTexture owner, string prefix)
    {
        Owner = owner.Owner;
        Prefix = owner.Prefix + prefix;

        var texKey = Prefix + "Tex";
        var texSizeKey = Prefix + "TexSize";
        var strengthKey = Prefix + "Strength";

        Texture = new(Owner, texKey);
        MappingScale = new(Owner, texSizeKey);
        Strength = new(Owner, strengthKey);

        Strength.SetIfEmpty(Vector2.One);
    }

    public bool IsTextureEmpty => string.IsNullOrEmpty(Texture.Value);
}