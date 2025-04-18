﻿using Grille.BeamNG.SceneTree;
using Grille.BeamNG.SceneTree.Main;
using Grille.BeamNG.SceneTree.Registry;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTemplateCreator.Assets;

public class LevelObjectsAsset : Asset<JsonDictWrapper>
{
    public const string ClassName = "LevelObjects";


    Collection<SimItem> Items;

    public LevelObjectsAsset(JsonDictWrapper data, AssetSource info) : base(data, info)
    {
        Items = new Collection<SimItem>();

        var rawitems = (JsonDict[])data["items"];

        foreach (var rawitem in rawitems)
        {
            var classname = (string)rawitem["class"];
            if (ItemClassRegistry.Instance.TryCreate<SimItem>(classname, rawitem, out var item))
            {

                Items.Add(item);
            }
            else
            {
                Items.Add(new SimItem(rawitem, classname));
            }
        }
    }

    public void Apply(SimGroupLevelObjects group)
    {
        foreach (var item in Items)
        {
            switch (item.Class.Value)
            {
                case "TimeOfDay":
                    group.Time.Items.Add(item);
                    break;
                case "CloudLayer":
                    group.Cloud.Items.Add(item);
                    break;
                case "ScatterSky":
                    group.Sky.Items.Add(item);
                    break;
                case "LevelInfo":
                    group.Infos.Items.Add(item);
                    break;
                case "Forest":
                case "ForestWindEmitter":
                    group.Vegatation.Items.Add(item);
                    break;
                default:
                    group.Misc.Items.Add(item);
                    break;
            }
        }
    }

    public override JsonDictWrapper GetCopy()
    {
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        return DisplayName;
    }
}