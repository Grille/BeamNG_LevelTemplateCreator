namespace Grille.BeamNgLib_Tests;

internal class Program
{
    static void Main(string[] args)
    {
        ExecuteImmediately = true;

        Terrain.Run();

        RunTestsSynchronously();
    }
}
