using LevelTemplateCreator.IO.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTemplateCreator.Assets;

abstract class Asset
{
    public string Name { get; set; } = string.Empty;

    public Image? Preview { get; set; }

    public void LoadPreview(string path)
    {
        using var stream = ResourceManager.Parse(path).OpenStream();
        var bitmap = new Bitmap(stream);
        Preview = bitmap;
    }
}
