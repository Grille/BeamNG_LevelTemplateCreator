namespace Grille.BeamNgLib.SceneTree.Main;

public class SimGroupMissionGroup : SimGroup
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
