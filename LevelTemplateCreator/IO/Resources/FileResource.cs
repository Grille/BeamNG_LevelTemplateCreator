using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTemplateCreator.IO.Resources;

internal class FileResource : Resource
{
    public string Path { get; }

    public FileResource(string name, string path) : base(name)
    {
        Path = path;
    }

    public override Stream OpenStream()
    {
        return new FileStream(Path, FileMode.Open);
    }
}
