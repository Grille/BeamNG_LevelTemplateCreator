using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grille.BeamNgLib.SceneTree.Art;
public class ManagedItems : ArtItemsCollection<ForestItemData>
{
    public const string FileName = "managedItemData.json";

    public ManagedItems(ArtGroup owner) : base(owner) { }

    public bool TrySaveToDirectory(string dirPath)
    {
        return TrySaveToDirectory(dirPath, FileName);
    }

    public bool TryLoadFromDirectory(string dirPath, ItemClassRegistry registry)
    {
        return TryLoadFromDirectory(dirPath, FileName, registry);
    }
}
