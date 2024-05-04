using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTemplateCreator.IO.Resources;

internal class ZipFileResource : Resource
{
    public string ZipFilePath { get; }
    public string Path { get; }

    public ZipFileResource(string name, string zipFilePath, string path) : base(name)
    {
        ZipFilePath = zipFilePath;
        Path = path;
    }

    public override Stream OpenStream()
    {
        var zipfile = ZipFile.OpenRead(ZipFilePath);
        var entry = zipfile.GetEntry(Path);
        if (entry == null)
            throw new Exception();
        return entry.Open();
    }
}
