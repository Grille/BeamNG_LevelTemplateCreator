using Grille.BeamNgLib.Collections;
using Grille.BeamNgLib.IO;
using Grille.BeamNgLib.IO.Resources;

namespace Grille.BeamNgLib.SceneTree.Art;

public class ArtGroup : IKeyed
{
    string IKeyed.Key => Name;

    public string Name { get; }

    public KeyedCollection<ArtGroup> Children { get; }

    public ResourceCollection Resources { get; }

    public MaterialLibary MaterialItems { get; }

    public ArtGroup(string name)
    {
        Name = name;
        Children = new();
        Resources = new(true);
        MaterialItems = new(Resources);
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

        var materialsPath = Path.Combine(path, MaterialLibary.FileName);
        MaterialItems.SerializeItems(materialsPath);

        foreach (var resource in Resources)
        {
            resource.SaveToDirectory(path);
        }
    }
}
