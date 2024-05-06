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
    public string EntryPath { get; }

    public ZipFileResource(string name, string zipFilePath, string path) : base(name)
    {
        ZipFilePath = zipFilePath;
        EntryPath = path;
    }

    public override Stream OpenStream()
    {
        var archive = ZipFileManager.Open(ZipFilePath);
        var entry = archive.GetEntry(EntryPath);

        if (entry == null)
        {
            var ext = Path.GetExtension(EntryPath).ToLower();
            if (ext == ".png")
            {
                DynamicName = Path.ChangeExtension(Name, ".dds");
                var path = Path.ChangeExtension(EntryPath, ".dds");
                entry = archive.GetEntry(path);
            }
        }

        if (entry == null)
        {
            throw new Exception($"Could not find '{EntryPath}' in '{ZipFilePath}'.");
        }

        return entry.Open();
    }

    public void Find()
    {

    } 
}
