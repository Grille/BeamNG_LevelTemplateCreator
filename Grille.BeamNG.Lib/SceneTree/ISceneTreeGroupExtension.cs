using Grille.BeamNG.SceneTree.Registry;
using Grille.BeamNG.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grille.BeamNG.SceneTree;

public static class ISceneTreeGroupExtension
{
    extension(ISceneTreeGroup group)
    {
        public void LoadTree(string path, ItemClassRegistry registry)
        {
            var vd = new VirtualDirectory();
            vd.AddDirectory(path, false);
            group.LoadTree(vd, registry);
        }

        public void LoadTree(string path)
        {
            group.LoadTree(path, ItemClassRegistry.Instance);
        }

        public void LoadTree(VirtualDirectory vd)
        {
            group.LoadTree(vd, ItemClassRegistry.Instance);
        }
    }
}
