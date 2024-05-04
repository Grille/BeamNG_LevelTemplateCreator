using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTemplateCreator.IO.Resources;

internal abstract class Resource
{
    public string Name { get; }

    public Resource(string name)
    {
        Name = name;
    }

    public abstract Stream OpenStream();

    public virtual void Save(string path)
    {
        using var src = OpenStream();
        using var dst = new FileStream(path, FileMode.Create);
        src.CopyTo(dst);
    }
}
