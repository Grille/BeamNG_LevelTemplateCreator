
namespace Grille.BeamNG.SceneTree.Art;
public class ArtItem : JsonDictWrapper
{
    public ArtItem(JsonDict dict, string className) : base(dict, className) { 
        if (className == null) 
            throw new ArgumentNullException("class");
    }
}
