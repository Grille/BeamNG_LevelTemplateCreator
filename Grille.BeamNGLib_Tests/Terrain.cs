using Grille.BeamNgLib.IO.Binary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Grille.BeamNgLib.IO;
using Grille.BeamNgLib;
using System.IO.Enumeration;

namespace Grille.BeamNgLib_Tests;

static class Terrain
{
    const string FileName = "terrain.ter";

    public static void Run()
    {
        Section("Terrain");

        Test("Terrain", TestTerrainFromInfo);
        Test("Terrain", TestTerrain);
    }

    static void TestTerrainFromInfo()
    {
        var names = new string[]
        {
            "Material0",
            "Material1",
        };

        float maxHeight = 512;
        float height = 10;
        var info = new TerrainInfo() { Height = height, MaxHeight = maxHeight };
        ushort u16height = info.U16Height;

        TerrainV9Serializer.Serialize(info, names, FileName);

        var result = TerrainV9Serializer.Deserialize(FileName);

        AssertIsEqual((int)height, (int)(result.Data[0].GetHeight(maxHeight) + 0.5f));

        for (int i = 0;i<result.Data.Length;i++)
        {
            AssertIsEqual(u16height, result.Data[i].Height);
        }

        AssertIListIsEqual(names, result.MaterialNames);
    }

    static void TestTerrain()
    {
        var names = new string[]
        {
            "Material0",
            "Material1",
        };

        var terrain = new TerrainBinary(64)
        {
            MaterialNames = names
        };

        TerrainV9Serializer.Serialize(terrain, FileName);

        var result = TerrainV9Serializer.Deserialize(FileName);

        AssertIListIsEqual(names, result.MaterialNames);
    }
}
