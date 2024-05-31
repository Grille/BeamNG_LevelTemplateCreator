using Grille.BeamNG.Collections;
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
    public JsonDictWrapper Object { get; }

    public string OriginalName { get; }

    public string Key { get; }

    public string DisplayName { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public bool Visible { get; set; }

    public Image Preview { get; private set; }

    public string SourceFile { get; }

    public string Namespace { get; }

    public AssetSource Info { get; }

    public string Class { get; }

    public Asset(JsonDictWrapper obj, AssetSource info)
    {
        Object = obj;

        if (!obj.Name.Exists)
        {
            throw new ArgumentException("Object must have a name.", nameof(obj));
        }
        Info = info;
        SourceFile = info.SourceFile;
        Namespace = info.Namespace;

        OriginalName = obj.Name.Value;

        obj.ApplyNamespace(Namespace);
        Key = obj.Name.Value;

        if (obj.TryPopValue("preview", out string path))
        {
            LoadPreview(path);
        }
        else
        {
            Preview = Resources.NoPreview;
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

    public void LoadPreview(string path)
    {
        try
        {
            var resource = PathExpressionEvaluator.Get(path, Info);
            using var stream = resource.Open();
            var bitmap = new Bitmap(stream);
            Preview = bitmap;
        }
        catch
        {
            Preview = Resources.InvalidPreview;
        }
    }
}

public abstract class Asset<T> : Asset where T : JsonDictWrapper
{
    public new T Object => (T)base.Object;

    public Asset(T obj, AssetSource info) : base(obj, info) { }

    public abstract T GetCopy();
}

