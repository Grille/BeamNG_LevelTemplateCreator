using Grille.BeamNgLib.SceneTree;
using System.Text;

namespace Grille.BeamNgLib.IO;

public static class ItemsLevelSerializer
{
    public static IEnumerable<JsonDict> Load(string path)
    {
        using var stream = new FileStream(path, FileMode.Open);
        return Deserialize(stream);
    }

    public static void Save(string path, IEnumerable<JsonDict> items)
    {
        using var stream = new FileStream(path, FileMode.Create);
        Serialize(stream, items);
    }

    public static void Serialize(Stream stream, IEnumerable<JsonDictWrapper> items)
    {
        using var sw = new StreamWriter(stream);
        foreach (var item in items)
        {
            JsonDictSerializer.Serialize(stream, item.Dict, false);
            stream.WriteByte((byte)'\n');
        }
    }

    public static void Serialize(Stream stream, IEnumerable<JsonDict> items)
    {
        using var sw = new StreamWriter(stream);
        foreach (var item in items)
        {
            JsonDictSerializer.Serialize(stream, item, false);
            stream.WriteByte((byte)'\n');
        }
    }

    public static IEnumerable<JsonDict> Deserialize(Stream stream)
    {
        using var sr = new StreamReader(stream);

        while (true)
        {
            var line = sr.ReadLine();
            if (line == null)
                break;

            var bytes = Encoding.UTF8.GetBytes(line);
            using var linestream = new MemoryStream(bytes);
            var dict = JsonDictSerializer.Deserialize(linestream);

            yield return dict;
        }
    }

    public static JsonDict[] DeserializeToArray(Stream stream)
    {
        var list = new List<JsonDict>();

        foreach (var item in Deserialize(stream))
        {
            list.Add(item);
        }

        return list.ToArray();
    }
}
