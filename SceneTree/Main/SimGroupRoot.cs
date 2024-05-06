using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTemplateCreator.SceneTree.Main;

internal class SimGroupRoot : SimGroup
{
    public SimGroupMissionGroup MissionGroup { get; }

    public SimGroupRoot() : base("main")
    {
        IsMain = true;

        MissionGroup = new SimGroupMissionGroup();

        Items.Add(MissionGroup);
    }
}
