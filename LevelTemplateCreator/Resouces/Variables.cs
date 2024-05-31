using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTemplateCreator.IO.Resources;
public static class Variables
{
    readonly static Dictionary<string, string> _dict;

    static Variables()
    {
        _dict = new Dictionary<string, string>();
    }

    public static void Set(string key, string value)
    {
        _dict[key] = value;
    }

    public static bool TryGet(string key, out string value) {
        return _dict.TryGetValue(key, out value!);
    }

    public static string Get(string key)
    {
        if (TryGet(key, out var value))
        {
            return value;
        }
        throw new KeyNotFoundException($"Key {key} not found.");
    }
}
