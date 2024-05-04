using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTemplateCreator.IO;

internal class RessourceFileManager
{
    public Dictionary<string, RessourceFile> Files;

    public string Register(string path)
    {
        path.StartsWith('/');
        var split = path.Split(Path.PathSeparator);

        return split[0];
    }
}
