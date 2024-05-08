using LevelTemplateCreator.IO.Resources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTemplateCreator.SceneTree.Art;

internal class ObjectMaterial : Material
{
    public const string ClassName = "Material";

    public JsonDictProperty<float> Version { get; }

    public ReadOnlyCollection<ObjectPbrMaterialStage> Stages { get; }

    public ObjectPbrMaterialStage Stage0 { get; }
    public ObjectPbrMaterialStage Stage1 { get; }
    public ObjectPbrMaterialStage Stage2 { get; }
    public ObjectPbrMaterialStage Stage3 { get; }

    public ObjectMaterial(JsonDict dict) : base(dict)
    {
        Version = new(this, "version");

        var stages = (JsonDict[])this["Stages"];

        Stage0 = new(stages[0]);
        Stage1 = new(stages[1]);
        Stage2 = new(stages[2]);
        Stage3 = new(stages[3]);

        Stages = new([Stage0, Stage1, Stage2, Stage3]);
    }

    public override void ResolveTexturePaths(MaterialLibary libary, string path)
    {
        foreach (var stage in Stages)
        {
            foreach (var map in stage.Maps)
            {
                if (!map.Exists)
                    continue;
                var key = libary.Textures.RegisterRelative(map.Value, path);
                map.Value = Path.Combine(libary.TexturesPath, key);
            }
        }
    }

    public override ObjectMaterial Copy()
    {
        var clone = new JsonDict(Dict);
        var stages = new JsonDict[4] { new(Stage0.Dict), new(Stage1.Dict), new(Stage2.Dict), new(Stage3.Dict) };
        clone["Stages"] = stages;

        return new ObjectMaterial(clone);
    }
}

class ObjectPbrMaterialStage : JsonDictWrapper
{
    public JsonDictProperty<string> AmbientOcclusionMap { get; }

    public JsonDictProperty<string> BaseColorMap { get; }

    public JsonDictProperty<string> NormalMap { get; }

    public JsonDictProperty<string> OpacityMap { get; }

    public JsonDictProperty<string> RoughnessMap { get; }

    public JsonDictProperty<string> ColorMap { get; }

    public JsonDictProperty<string> SpecularMap { get; }

    public ReadOnlyCollection<JsonDictProperty<string>> Maps { get; }

    public ObjectPbrMaterialStage(JsonDict dict) : base(dict)
    {
        AmbientOcclusionMap = new(this, "ambientOcclusionMap");
        BaseColorMap = new(this, "baseColorMap");
        NormalMap = new(this, "normalMap");
        OpacityMap = new(this, "opacityMap");
        RoughnessMap = new(this, "roughnessMap");
        ColorMap = new(this, "colorMap");
        SpecularMap = new(this, "specularMap");

        Maps = new([AmbientOcclusionMap, BaseColorMap, NormalMap, OpacityMap, RoughnessMap, ColorMap, SpecularMap]);
    }
}
