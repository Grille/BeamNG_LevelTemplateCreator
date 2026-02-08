using Grille.BeamNG.Collections;
using Grille.BeamNG.IO;
using Grille.BeamNG.IO.Resources;
using Grille.BeamNG.SceneTree.Registry;

namespace Grille.BeamNG.SceneTree.Art;

public class ArtGroup : ISceneTreeGroup
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
        MaterialItems = new(this);
        ManagedItems = new(this);
    }

    public void SaveTree(string dirPath, bool ignoreEmpty = true)
    {
        Directory.CreateDirectory(dirPath);

        foreach (var item in Children)
        {
            if (item.IsEmpty && ignoreEmpty)
                continue;
            var childpath = Path.Combine(dirPath, item.Name);
            item.SaveTree(childpath, ignoreEmpty);
        }

        MaterialItems.TrySaveToDirectory(dirPath);
        ManagedItems.TrySaveToDirectory(dirPath);

        foreach (var resource in Resources)
        {
            resource.SaveToDirectory(dirPath);
        }
    }
     
    public void LoadTree(VirtualDirectory vd, ItemClassRegistry registry)
    {
        foreach (var item in vd.Directories)
        {
            var name = Path.GetFileName(item.Key);
            var group = new ArtGroup(name);
            Children.Add(group);
            group.LoadTree(item.Value, registry);
        }

        MaterialItems.TryLoadFromDirectory(vd, registry);
        ManagedItems.TryLoadFromDirectory(vd, registry);

        foreach (var file in vd.Files)
        {
            var ext = Path.GetExtension(file.Key);
            if (ext.ToLower() == ".json")
                continue;

            var name = Path.GetFileName(file.Key);

            var resouce = file.Value;

            Resources.Add(resouce);
        }
    }
}
