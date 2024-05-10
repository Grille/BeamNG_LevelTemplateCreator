using Grille.BeamNgLib.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grille.BeamNgLib.SceneTree.Main;
public class SimItemCollection : JsonDictWrapperCollection<SimItem>
{
    public SimGroup Owner { get; }

    public SimItemCollection(SimGroup owner)
    {
        Owner = owner;
    }

    public override void Serialize(Stream stream)
    {
        foreach (var item in this)
        {
            item.SetParent(Owner.IsMain ? null : Owner);
        }
        SimItemsJsonSerializer.Serialize(stream, this);
    }

    public override void Deserialize(Stream stream, ItemClassRegistry registry)
    {
        foreach (var dict in SimItemsJsonSerializer.Deserialize(stream))
        {
            var className = (string)dict["class"];

            if (registry.TryCreate<SimItem>(className, dict, out var obj))
            {
                Add(obj);
            }
            else
            {
                Add(new SimItem(dict, className));
            }

        }
    }
}
