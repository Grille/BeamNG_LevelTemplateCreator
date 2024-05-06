using LevelTemplateCreator.IO.Resources;
using LevelTemplateCreator.SceneTree;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTemplateCreator.Assets;

abstract class Asset
{
    public string Name { get; set; } = string.Empty;

    public Image Preview { get; set; }

    public string SourceFile { get; }

    public Asset(JsonDictWrapper obj, string source)
    {
        SourceFile = source;

        if (obj.TryPopValue("preview", out string path))
        {
            try
            {
                using var stream = ResourceManager.Parse(path, source).OpenStream();
                var bitmap = new Bitmap(stream);
                Preview = bitmap;
            }
            catch { 
                Preview = Properties.Resources.InvalidPreview;
            }
        }
        else
        {
            Preview = Properties.Resources.NoPreview;
        }
    }

}
