namespace Grille.BeamNgLib.SceneTree.Art;
public class ArtGroupRoot : ArtGroup
{
    public ArtGroup Terrains { get; }

    public ArtGroup Groundcover { get; }

    public ArtGroupRoot() : base("art")
    {
        Terrains = new("terrains");
        Groundcover = new("groundcover");

        Children.Add(Terrains);
        Children.Add(Groundcover);
    }
}
