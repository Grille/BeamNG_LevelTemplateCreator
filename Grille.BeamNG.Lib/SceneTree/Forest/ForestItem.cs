using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grille.BeamNG.SceneTree.Forest;

public class ForestItem : JsonDictWrapper
{
    public JsonDictProperty<Vector3> Position { get; }

    public ForestItem(JsonDict dict) : base(dict)
    {
        Position = new(this, "position");
    }
}
