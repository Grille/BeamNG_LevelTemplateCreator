using Grille.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grille.BeamNG.IO.Binary;
internal static class BinaryViewExtensions
{
    public static byte ReadVersion(this BinaryViewReader br, byte expected, bool ignoreVersion)
    {
        byte version = br.ReadByte();
        if (version != expected && !ignoreVersion)
        {
            throw new InvalidDataException($"Unsupported terrain version '{version}'.");
        }
        return version;
    }

    public static void Fill<T>(this BinaryViewWriter bw, T value, long count) where T : unmanaged 
    {
        for (int i = 0; i < count; i++)
        {
            bw.Write(value);
        }
    }

    public static void WriteMaterialNames(this BinaryViewWriter bw, string[] names)
    {
        bw.WriteUInt32((uint)names.Length);
        for (int i = 0; i < names.Length; i++)
        {
            bw.WriteString(names[i], LengthPrefix.Byte, Encoding.UTF8);
        }
    }

    public static string[] ReadMaterialNames(this BinaryViewReader br)
    {
        uint materialCount = br.ReadUInt32();
        var names = new string[materialCount];
        for (int i = 0; i < materialCount; i++)
        {
            names[i] = br.ReadString(LengthPrefix.Byte, Encoding.UTF8);
        }
        return names;
    }

}
