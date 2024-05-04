using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTemplateCreator.SceneTree;

internal class SimGroupLevelObject : SimGroup
{
    public SimGroup Cloud { get; }

    public SimGroup Infos { get; }

    public SimGroup Sky { get; }

    public SimGroup Terrain { get; }

    public SimGroup Time { get; }

    public SimGroup Vegatation { get; }

    public SimGroupLevelObject() : base("Level_object")
    {
        Cloud = new("cloud");
        Infos = new("Infos");
        Sky = new("Sky");
        Terrain = new("terrain");
        Time = new("time");
        Vegatation = new("vegatation");

        Items.Add(Cloud, Infos, Sky, Terrain, Time, Vegatation);
    }
}
