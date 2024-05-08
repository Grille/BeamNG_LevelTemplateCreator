using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GGL.IO;
using LevelTemplateCreator.SceneTree.Art;

namespace LevelTemplateCreator.IO;

static class TerrainV9Serializer
{
    public static void Serialize(TerrainInfo info, ICollection<string> materials, string path)
    {
        using var stream = new FileStream(path, FileMode.Create);
        Serialize(info, materials, stream);
    }

    public static void Serialize(TerrainInfo info, ICollection<string> materials, Stream stream)
    {
        using var bw = new BinaryViewWriter(stream);

        bw.WriteByte(9);
        bw.WriteUInt32((uint)info.Resolution);

        long size = info.Resolution * (long)info.Resolution;

        float u16max = ushort.MaxValue;

        float height = info.Height / info.MaxHeight * u16max;
        if (height > u16max)
            height = u16max;

        ushort u16height = (ushort)height;

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
}
