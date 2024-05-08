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
        return PopFromObject(obj);
    }

    static GroundCoverInstance[] PopFromObject(JsonDictWrapper obj)
    {
        var array = new JsonDictProperty<JsonDict[]>(obj, "Types");

        if (!array.Exists)
            return Array.Empty<GroundCoverInstance>();

        var result = new List<GroundCoverInstance>();

        for (int i = 0; i < array.Value.Length; i++)
        {
            var dict = array.Value[i];
            if (dict.Count == 0) 
                continue;

            var instance = new GroundCoverInstance(dict);
            instance["parent"] = obj.Name.Value;
            result.Add(instance);
        }

        array.Remove();

        return result.ToArray();
    }

    public override GroundCoverInstance Copy()
    {
        var dict = new JsonDict(Dict);
        return new GroundCoverInstance(dict);
    }

    public override void ApplyPrefix(string prefix)
    {
        base.ApplyPrefix(prefix);

        Layer.Value = prefix + Layer.Value;
    }
}
