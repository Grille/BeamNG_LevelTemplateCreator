using System.Text;
using GGL.IO;
using Grille.BeamNgLib.IO.Binary;

namespace Grille.BeamNgLib.IO;

public class TerrainV9Serializer
{
    public static TerrainBinary Load(string path, bool ignoreVersion = false)
    {
        using var stream = new FileStream(path, FileMode.Open);
        return Deserialize(stream, ignoreVersion);
    }

    public static void Save(string path, TerrainBinary terrain)
    {
        using var stream = new FileStream(path, FileMode.Create);
        Serialize(stream, terrain);
    }

    public static void Save(string path, TerrainInfo info, ICollection<string> materials)
    {
        using var stream = new FileStream(path, FileMode.Create);
        Serialize(stream, info, materials);
    }

    public static TerrainBinary Deserialize(Stream stream, bool ignoreVersion = false)
    {
        using var br = new BinaryViewReader(stream);

        byte version = br.ReadByte();
        if (version != 9 && !ignoreVersion)
        {
            throw new InvalidDataException($"Unsupported terrain version '{version}'.");
        }

        int size = (int)br.ReadUInt32();

        var terrain = new TerrainBinary(size);

        int sqsize = size * size;

        var data = terrain.Data;

        for (int i = 0; i< sqsize; i++)
        {
            data[i].Height = br.ReadUInt16();
        }
        for (int i = 0; i < sqsize; i++)
        {
            data[i].Material = br.ReadByte();
        }

        int materialCount = (int)br.ReadUInt32();
        terrain.MaterialNames = new string[materialCount];

        for (int i = 0; i < materialCount; i++)
        {
            terrain.MaterialNames[i] = br.ReadString(LengthPrefix.Byte, Encoding.UTF8);
        }

        return terrain;
    }

    public static void Serialize(Stream stream, TerrainBinary terrain)
    {
        using var bw = new BinaryViewWriter(stream);

        int size = terrain.Size;
        int sqsize = size * size;

        if (terrain.Data.Length != sqsize)
            throw new ArgumentException("Data.Length must equal Data.Size^2.");

        bw.WriteByte(9);
        bw.WriteUInt32((uint)size);

        var data = terrain.Data;

        for (int i = 0;i < sqsize; i++)
        {
            bw.WriteUInt16(data[i].Height);
        }
        for (int i = 0;i < sqsize; i++)
        {
            bw.WriteByte(data[i].Material);
        }

        var names = terrain.MaterialNames;
        bw.WriteUInt32((uint)names.Length);
        for (int i = 0; i < names.Length; i++)
        {
            bw.WriteString(names[i], LengthPrefix.Byte, Encoding.UTF8);
        }
    }

    public static void Serialize(Stream stream, TerrainInfo info, ICollection<string> materials)
    {
        using var bw = new BinaryViewWriter(stream);

        bw.WriteByte(9);
        bw.WriteUInt32((uint)info.Resolution);

        long size = info.Resolution * (long)info.Resolution;
        ushort u16height = info.U16Height;

        for (int i = 0; i < size; i++)
        {
            bw.WriteUInt16(u16height);
        }

        bw.Seek(size, SeekOrigin.Current);

        bw.WriteUInt32((uint)materials.Count);

        foreach (var material in materials)
        {
            bw.WriteString(material, LengthPrefix.Byte, Encoding.UTF8);
        }
    }

    public static ushort GetU16Height(float height, float maxHeight)
    {
        float u16max = ushort.MaxValue;

        float u16height = height / maxHeight * u16max;
        if (u16height > u16max)
            u16height = u16max;

        return (ushort)u16height;
    }

    public static float GetSingleHeight(ushort u16height, float maxHeight)
    {
        float height = u16height;
        float u16max = ushort.MaxValue;

        return (height / u16max) * maxHeight;
    }
}
