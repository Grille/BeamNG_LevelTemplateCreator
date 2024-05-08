using LevelTemplateCreator.Collections;
using LevelTemplateCreator.IO.Resources;
using LevelTemplateCreator.SceneTree;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace LevelTemplateCreator.Assets;

abstract class Asset : IKeyed
{
    string IKeyed.Key => Object.Name.Value;

    public string DisplayName { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public bool Visible { get; set; }

    public Image Preview { get; }

    public string SourceFile { get; }

    public string Namespace { get; }

    public AssetInfo Info { get; }

    public JsonDictWrapper Object { get; }

    public Asset(JsonDictWrapper obj, AssetInfo info)
    {
        Info = info;
        Object = obj;
        SourceFile = info.SourceFile;
        Namespace = info.Namespace;

        obj.ApplyNamespace(Namespace);

        if (obj.TryPopValue("preview", out string path))
        {
            try
            {
                using var stream = ResourceManager.Parse(path, SourceFile).OpenStream();
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
            DisplayName = Object.Name.Value;
        }

        if (obj.TryPopValue("description", out string desc))
        {
            Description = desc;
        }
    }

    public virtual JsonDictWrapper GetCopy()
    {
        return Object.Copy();
    }
}

abstract class Asset<T> : Asset where T : JsonDictWrapper
{
    public new T Object => (T)base.Object;

    public Asset(T obj, AssetInfo info) : base(obj, info) { }

    public override T GetCopy()
    {
        return (T)Object.Copy();
    }
}

