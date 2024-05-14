using Grille.BeamNG.IO.Binary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grille.BeamNG;
using System.IO.Enumeration;

namespace Grille.BeamNgLib_Tests;

static class TerrainSection
{
    const string FileName = "terrain.ter";

    static string[] MaterialNames = ["Material0", "Material1"];

    public static void Run()
    {
        Section("Terrain");

        Test("TerrainTemplate", TestTerrainTemplate);
        Test("TerrainV9Binary", TestTerrain);
        Test("TestAbstractTerrain", TestAbstractTerrain);
    }

    static void TestTerrainTemplate()
    {
        float maxHeight = 512;
        float height = 10;
        var terrain = new TerrainTemplate() { Height = height, MaxHeight = maxHeight, MaterialNames = MaterialNames };
        ushort u16height = terrain.U16Height;

        terrain.Save(FileName);

        var result = TerrainV9Serializer.Load(FileName);

        AssertIsEqual(u16height, result.HeightData[0]);

        for (int i = 0;i<result.HeightData.Length;i++)
        {
            AssertIsEqual(u16height, result.HeightData[i]);
        }

        AssertIListIsEqual(MaterialNames, result.MaterialNames);
    }

    static void TestTerrain()
    {
        var names = new string[]
        {
            "Material0",
            "Material1",
        };

        var terrain = new TerrainV9Binary(64)
        {
            MaterialNames = names
        };

        TerrainV9Serializer.Save(FileName, terrain);

        var result = TerrainV9Serializer.Load(FileName);

        AssertIListIsEqual(names, result.MaterialNames);
    }

    static void TestAbstractTerrain()
    {
        float maxHeight = 512;
        var terrain1 = new Terrain(8);
        terrain1.Data[1, 1].Height = 8.5f;
        terrain1.Data[2, 2].IsHole = true;
        terrain1.Data[3, 3].Material = 45;
        terrain1.Save(FileName, maxHeight);


        var terrain2 = new Terrain();
        terrain2.Load(FileName, maxHeight);

        AssertIsEqual(terrain1.Size, terrain2.Size);
        AssertIListIsEqual(terrain1.MaterialNames, terrain2.MaterialNames);

        int length = terrain1.Data.Length;
        for (int i = 0; i < length; i++)
        {
            AssertIsEqual(Math.Round(terrain1.Data[i].Height, 1), Math.Round(terrain2.Data[i].Height, 1));
            AssertIsEqual(terrain1.Data[i].Material, terrain2.Data[i].Material);
            AssertIsEqual(terrain1.Data[i].IsHole, terrain2.Data[i].IsHole);
        }
    }
}
