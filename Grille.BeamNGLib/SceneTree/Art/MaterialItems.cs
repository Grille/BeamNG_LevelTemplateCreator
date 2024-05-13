using Grille.BeamNgLib.Collections;
using Grille.BeamNgLib.IO;
using Grille.BeamNgLib.IO.Resources;
using Grille.BeamNgLib.SceneTree.Main;
using Grille.BeamNgLib.SceneTree.Registry;

namespace Grille.BeamNgLib.SceneTree.Art;

public class MaterialItems : ArtItemsCollection<ArtItem>
{
    public const string FileName = "main.materials.json";

    public ResourceCollection Resources { get; }

    public MaterialItems(ArtGroup owner, ResourceCollection resources) : base(owner)
    {
        Resources = resources;
    }

    public string[] GetMaterialNames()
    {
        List<string> names = new List<string>();
        foreach (var material in Enumerate<Material>())
        {
            names.Add(material.Name.Value);
        }
        return names.ToArray();
    }

    public bool TrySaveToDirectory(string dirPath)
    {
        return TrySaveToDirectory(dirPath, FileName);
    }

    public bool TryLoadFromDirectory(string dirPath, ItemClassRegistry registry)
    {
        return TryLoadFromDirectory(dirPath, FileName, registry);
    }

    public override void EnumerateRecursive<T>(ICollection<T> values)
    {
        foreach (var item in Enumerate<T>())
        {
            values.Add(item);
        }

        foreach (var group in Owner.Children)
        {
            group.MaterialItems.EnumerateRecursive(values);
        }
    }
}
