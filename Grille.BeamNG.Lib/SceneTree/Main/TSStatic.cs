using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grille.BeamNG.SceneTree.Main;
public class TSStatic : SimItem
{
    public const string ClassName = "TSStatic";

    public TSStatic(JsonDict? dict) : base(dict, ClassName)
    {
    }
}
