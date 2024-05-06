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
        var zipfile = ZipFile.OpenRead(ZipFilePath);
        var entry = zipfile.GetEntry(EntryPath);

        if (entry == null)
        {
            var match = Path.ChangeExtension(EntryPath, null).ToLower();

            foreach (var e in zipfile.Entries)
            {
                var zipmatch = Path.ChangeExtension(e.FullName, null).ToLower();
                if (zipmatch == match)
                {
                    entry = e;
                }
            }
        }

        if (entry == null)
            throw new Exception($"Could not find '{EntryPath}' in '{ZipFilePath}'.");

        return entry.Open();
    }

    public void Find()
    {

    } 
}
