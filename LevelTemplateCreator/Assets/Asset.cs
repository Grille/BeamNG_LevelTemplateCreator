﻿using Grille.BeamNG.Collections;
using Grille.BeamNG.SceneTree;
using LevelTemplateCreator.IO.Resources;
using LevelTemplateCreator.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LevelTemplateCreator.Assets;

public abstract class Asset : IKeyed
{
    public string Key { get; }

    public string DisplayName { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public bool Visible { get; set; }

    public Image Preview { get; }

    public string SourceFile { get; }

    public string Namespace { get; }

    public AssetSource Info { get; }

    public string Class { get; }

    public Asset(JsonDictWrapper obj, AssetSource info)
    {
        if (!obj.Name.Exists)
        {
            throw new ArgumentException("Object must have a name.", nameof(obj));
        }
        Info = info;
        SourceFile = info.SourceFile;
        Namespace = info.Namespace;

        obj.ApplyNamespace(Namespace);
        Key = obj.Name.Value;

        if (obj.TryPopValue("preview", out string path))
        {
            try
            {
                var resource = PathExpressionEvaluator.Get(path, info);
                using var stream = resource.Open();
                var bitmap = new Bitmap(stream);
                Preview = bitmap;
            }
            catch
            {
                Preview = Properties.Resources.InvalidPreview;
            }
        }
        else
        {
            Preview = Properties.Resources.NoPreview;
        }

        if (obj.TryPopValue("displayName", out string name))
        {
            DisplayName = name;
        }
        else if (obj.Name.Exists)
        {
            DisplayName = obj.Name.Value;
        }

        if (obj.TryPopValue("description", out string desc))
        {
            Description = desc;
        }

        if (obj.TryGetValue("class", out string @class)){
            Class = @class;
        }
        else
        {
            Class = string.Empty;
        }

    }
}

public abstract class Asset<T> : Asset where T : JsonDictWrapper
{
    public T Object { get; }

    public Asset(T obj, AssetSource info) : base(obj, info) { 
        Object = obj;
    }

    public abstract T GetCopy();
}

