﻿using LevelTemplateCreator.SceneTree;
using LevelTemplateCreator.SceneTree.Main;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTemplateCreator.Assets;

internal class LevelPreset : Asset
{
    public const string ClassName = "LevelPreset";

    Collection<SimItem> Items;

    public LevelPreset(JsonDictWrapper data, string file) : base(data, file)
    {
        Items = new Collection<SimItem>();

        Name = data.Name.Value;

        var rawitems = (JsonDict[])data["items"];

        foreach (var rawitem in rawitems)
        {
            var item = new SimItem(rawitem);
            foreach (var pair in rawitem)
            {
                item[pair.Key] = pair.Value;
            }
            Items.Add(item);
        }
    }

    public void Apply(SimGroupLevelObject group)
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
                case "ForestWindEmitter":
                    group.Vegatation.Items.Add(item);
                    break;
                default:
                    group.Misc.Items.Add(item);
                    break;
            }
        }
    }

    public override string ToString()
    {
        return Name;
    }
}