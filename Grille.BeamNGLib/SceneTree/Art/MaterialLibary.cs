using Grille.BeamNgLib.Collections;
using Grille.BeamNgLib.IO;
using Grille.BeamNgLib.IO.Resources;

namespace Grille.BeamNgLib.SceneTree.Art;

public class MaterialLibary : KeyedCollection<ArtItem>
{
    public const string FileName = "main.materials.json";

    public ResourceCollection Resources { get; }

    public MaterialLibary(ResourceCollection resources)
    {
        Resources = resources;
    }

    public string[] GetMaterialNames()
    {
        List<string> names = new List<string>();
        foreach (var material in EnumerateItems<Material>())
        {
            names.Add(material.Name.Value);
        }
        return names.ToArray();
    }

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
