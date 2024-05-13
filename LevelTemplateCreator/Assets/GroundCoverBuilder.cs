using Grille.BeamNG.Collections;
using Grille.BeamNG.SceneTree.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTemplateCreator.Assets;
public class GroundCoverBuilder : IKeyed
{
    GroundCoverAsset _groundCover;

    List<GroundCoverInstance> _instances;

    string IKeyed.Key => _groundCover.Object.Name.Value;

    public GroundCoverBuilder(GroundCoverAsset groundCover)
    {
        _groundCover = groundCover;
        _instances = new List<GroundCoverInstance>();
    }

    public void AddInstance(GroundCoverInstance instance)
    {
        var dict = new JsonDict(instance.Dict);
        var copy = new GroundCoverInstance(dict);
        copy.Parent.Remove();
        _instances.Add(copy);
    }

    public GroundCover Create()
    {
        var copy = _groundCover.GetCopy();

        var array = new JsonDict[8];

        for (int i = 0; i < 8; i++)
        {
            array[i] = i < _instances.Count ? _instances[i].Dict : new JsonDict();
        }

        copy.Types.Value = array;

        return copy;
    }
}
