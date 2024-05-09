using Grille.BeamNgLib.Collections;
using Grille.BeamNgLib.IO;
using Grille.BeamNgLib.IO.Resources;

namespace Grille.BeamNgLib.SceneTree.Art;

public class ArtGroup : IKeyed
{
    string IKeyed.Key => Name;

    public bool IsEmpty => Children.Count == 0 && Resources.Count == 0 && MaterialItems.Count == 0;

    public string Name { get; }

    public KeyedCollection<ArtGroup> Children { get; }

    public ResourceCollection Resources { get; }

    public MaterialItems MaterialItems { get; }

    public ManagedItems ManagedItems { get; }

    public ArtGroup(string name)
    {
        Name = name;
        Children = new();
        Resources = new(true);
        MaterialItems = new(Resources);
        ManagedItems = new();
    }

    public IEnumerable<T> EnumerateMaterialItems<T>() where T : ArtItem
    {
        foreach (var item in MaterialItems)
        {
            if (item is T)
            {
                yield return (T)item;
            }
        }
    }

    public void SaveTree(string path)
    {
        Directory.CreateDirectory(path);

        foreach (var item in Children)
        {
            var childpath = Path.Combine(path, item.Name);
            item.SaveTree(childpath);
        }

        if (MaterialItems.Count > 0)
        {
            var materialsPath = Path.Combine(path, MaterialItems.FileName);
            MaterialItems.SerializeItems(materialsPath);
        }

        foreach (var resource in Resources)
        {
            resource.SaveToDirectory(path);
        }
    }
}
