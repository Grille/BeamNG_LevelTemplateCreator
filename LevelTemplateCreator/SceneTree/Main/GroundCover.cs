using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTemplateCreator.SceneTree.Main;

internal class GroundCover : SimItem
{
    public const string ClassName = "GroundCover";

    public JsonDictProperty<string> Material { get; }

    public JsonDictProperty<JsonDict[]> Types { get; }

    public GroundCover(JsonDict dict) : base(dict)
    {
        Material = new(this, "material");

        Types = new(this, "Types");
    }

    public override GroundCover Copy()
    {
        if (Types.Exists)
        {
            throw new Exception();
        }

        var dict = new JsonDict(Dict);
        return new GroundCover(dict);
    }

    public void AddInstance(GroundCoverInstance instance)
    {

    }

    public override void ApplyPrefix(string prefix)
    {
        base.ApplyPrefix(prefix);

        Material.Value = prefix + Material.Value;
    }
}
