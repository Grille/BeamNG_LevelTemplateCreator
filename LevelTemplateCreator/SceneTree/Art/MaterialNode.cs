using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTemplateCreator.SceneTree.Art;

internal class MaterialNode
{
    public string Name { get; }

    public List<Material> Children { get; }

    public MaterialNode(string name)
    {
        Name = name;

        Children = new List<Material>();
    }

    public void SaveTree()
    {

    }
}
