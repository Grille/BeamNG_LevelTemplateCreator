using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTemplateCreator.SceneTree.Main;

internal class SimGroupMissionGroup : SimGroup
{
    public SimGroupLevelObject LevelObject { get; }

    public SimGroupMissionGroup() : base("MissionGroup")
    {
        LevelObject = new SimGroupLevelObject();

        Items.Add(LevelObject);
    }
}
