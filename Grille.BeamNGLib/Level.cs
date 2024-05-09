using Grille.BeamNgLib.SceneTree.Art;
using Grille.BeamNgLib.SceneTree.Main;

namespace Grille.BeamNgLib;

public class Level
{
    public LevelInfo Info { get; }

    public TerrainInfo Terrain { get; }

    public SimGroupRoot Main {  get; }

    public ArtGroupRoot Art { get; }

    public Level()
    {
        Info = new LevelInfo();
        Terrain = new TerrainInfo();

        Main = new SimGroupRoot();
        Art = new ArtGroupRoot();
    }
}
