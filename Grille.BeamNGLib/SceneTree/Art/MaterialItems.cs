using Grille.BeamNgLib.Collections;
using Grille.BeamNgLib.IO;
using Grille.BeamNgLib.IO.Resources;

namespace Grille.BeamNgLib.SceneTree.Art;

public class MaterialItems : ArtItemsCollection<ArtItem>
{
    public const string FileName = "main.materials.json";

    public ResourceCollection Resources { get; }

    public MaterialItems(ResourceCollection resources)
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
}
