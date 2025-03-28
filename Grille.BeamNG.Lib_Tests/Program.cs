﻿using Grille.BeamNG.Lib_Tests.Sections;

namespace Grille.BeamNgLib_Tests;

internal class Program
{
    static void Main(string[] args)
    {
        ExecuteImmediately = false;

        TerrainSection.Run();
        TerrainPaintSection.Run();
        SimTreeSection.Run();
        ArtTreeSection.Run();

        RunTestsSynchronously();
    }
}
