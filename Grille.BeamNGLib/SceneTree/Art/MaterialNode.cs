namespace Grille.BeamNgLib.SceneTree.Art;

public class MaterialNode
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
