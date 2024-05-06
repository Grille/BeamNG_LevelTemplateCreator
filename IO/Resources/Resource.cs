using LevelTemplateCreator.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTemplateCreator.IO.Resources;

internal abstract class Resource
{
    public string Name { get; }

    public string DynamicName { get; protected set; }

    public Resource(string name)
    {
        Name = name;
        DynamicName = name;
    }

    public abstract Stream OpenStream();

    public void SaveToDirectory(string directory)
    {
        using var stream = OpenStream();
        var dstpath = Path.Combine(directory, DynamicName);
        using var file = File.OpenWrite(dstpath);
        stream.CopyTo(file);
    }

    public void Save(string path)
    {
        using var src = OpenStream();
        using var dst = new FileStream(path, FileMode.Create);
        src.CopyTo(dst);
    }
}
