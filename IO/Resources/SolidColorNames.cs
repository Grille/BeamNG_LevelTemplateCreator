using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LevelTemplateCreator.IO.Resources;

internal static class SolidColorNames
{
    static readonly Dictionary<string, uint> _colors;

    public const string BaseNormal = "#base_nm";
    public const string BaseHeight= "#base_h";
    public const string BaseAmbientOcclusion = "#base_ao";
    public const string BaseColor = "#base_b";
    public const string BaseRoughness = "#base_r";

    public const string ConcreteRoughness = "#concrete_r";
    public const string AsphaltRoughness = "#asphalt_r";
    public const string AsphaltWetRoughness = "#asphalt_wet_r";

    public const string GrassRoughness = "#grass_r";
    public const string SandRoughness = "#sand_r";
    public const string DirtRoughness = "#dirt_r";
    public const string RockRoughness = "#rock_r";
    public const string MudRoughness = "#mud_r";

    static SolidColorNames()
    {
        _colors = new Dictionary<string, uint>();
        _colors[BaseNormal] = 0x7f7fff;
        _colors[BaseAmbientOcclusion] = 0xffffff;
        _colors[BaseHeight] = 0x000000;
        _colors[BaseRoughness] = 0xe7e7e7;
        _colors[BaseColor] = 0x808080;

        _colors[ConcreteRoughness] = 0xd4d4d4;
        _colors[AsphaltRoughness] = 0xd4d4d4;
        _colors[AsphaltWetRoughness] = 0x464646;
        _colors[GrassRoughness] = 0xe7e7e7;
        _colors[SandRoughness] = 0xe7e7e7;
        _colors[DirtRoughness] = 0xe7e7e7;
        _colors[RockRoughness] = 0xd4d4d4;
        _colors[MudRoughness] = 0x464646;
    }

    public static bool TryGet(string key, out int hex)
    {
        if (_colors.TryGetValue(key, out uint value))
        {
            hex = Unsafe.As<uint, int>(ref value);
            return true;
        }
        hex = 0;
        return false;
    }
}
