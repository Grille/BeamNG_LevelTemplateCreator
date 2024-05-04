using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LevelTemplateCreator.SceneTree;
using GGL.IO;

namespace LevelTemplateCreator.IO;

static class TerrainV9Serializer
{
    public static void Serialize(TerrainInfo info, ICollection<TerrainMaterial> materials, string path)
    {
        using var stream = new FileStream(path, FileMode.Create);
        Serialize(info, materials, stream);
    }

    public static void Serialize(TerrainInfo info, ICollection<TerrainMaterial> materials, Stream stream)
    {
        using var bw = new BinaryViewWriter(stream);

        bw.WriteByte(9);
        bw.WriteUInt32((uint)info.Resolution);

        long size = info.Resolution * (long)info.Resolution;

        bw.Seek(size * 3L, SeekOrigin.Current);

        bw.WriteUInt32((uint)materials.Count);

        foreach (var material in materials)
        {
            bw.WriteString(material.InternalName, LengthPrefix.Byte, Encoding.UTF8);
        }
    }
}
