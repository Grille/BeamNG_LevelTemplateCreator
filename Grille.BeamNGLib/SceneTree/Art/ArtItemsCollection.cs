using Grille.BeamNgLib.Collections;
using Grille.BeamNgLib.IO;

namespace Grille.BeamNgLib.SceneTree.Art;

public abstract class ArtItemsCollection<T> : KeyedCollection<T> where T : ArtItem
{
    public void SerializeItems(string path)
    {
        using var stream = new FileStream(path, FileMode.Create);
        SerializeItems(stream);
    }

    public void SerializeItems(Stream stream)
    {
        var dict = new JsonDict();

        foreach (var item in this)
        {
            dict[item.Name.Value] = item.Dict;
        }

        JsonDictSerializer.Serialize(stream, dict, true);
    }
}
