using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTemplateCreator.SceneTree.Main;

internal class SimGroupMissionGroup : SimGroup
{
    public SimGroupLevelObjects LevelObject { get; }

    public SimGroup PlayerDropPoints { get; }

    public SimGroupMissionGroup() : base("MissionGroup")
    {
        LevelObject = new SimGroupLevelObjects();
        PlayerDropPoints = new SimGroup("PlayerDopPoints");

        Items.Add(LevelObject, PlayerDropPoints);
    }
}
