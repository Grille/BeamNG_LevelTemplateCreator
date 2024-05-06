using LevelTemplateCreator.SceneTree.Art;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTemplateCreator.SceneTree.Main;

internal class GroundCoverInstance : JsonDictWrapper
{
    public const string ClassName = "GroundCover_Instance";

    public JsonDictProperty<string> Layer { get; }

    public JsonDictProperty<string> Parent { get; }

    public GroundCoverInstance(JsonDict dict) : base(dict)
    {
        Layer = new(this, "layer");
        Parent = new(this, "parent");
    }

    public static GroundCoverInstance[] PopFromGroundcover(GroundCover obj)
    {
        return PopFromObject(obj, "Types", "parent");
    }

    public static GroundCoverInstance[] PopFromMaterial(TerrainPbrMaterial obj)
    {
        return PopFromObject(obj, "groundcover", "layer");
    }

    static GroundCoverInstance[] PopFromObject(JsonDictWrapper obj, string name, string parent)
    {
        var array = new JsonDictProperty<JsonDict[]>(obj, name);

        if (!array.Exists)
            return Array.Empty<GroundCoverInstance>();

        var result = new GroundCoverInstance[array.Value.Length];
        for (int i = 0; i < array.Value.Length; i++)
        {
            var instance = new GroundCoverInstance(array.Value[i]);
            instance[parent] = obj.Name.Value;
            result[i] = instance;
        }

        array.Remove();

        return result;
    }
}
