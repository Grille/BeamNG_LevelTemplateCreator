using Grille.BeamNgLib.Collections;

namespace Grille.BeamNgLib.IO.Resources;

public class ResourceCollection : KeyedCollection<Resource>
{
    public ResourceCollection() { }

    public ResourceCollection(bool ignoreFalseDuplicates)
    {
        IgnoreFalseDuplicates = ignoreFalseDuplicates;
    }

    public void Save(string dirPath)
    {
        foreach (var resource in this)
        {
            resource.SaveToDirectory(dirPath);
        }
    }
}
