using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTemplateCreator.Scripting;
public class CfgScriptEvaluator
{
    public CfgScript Cfg { get; }

    public Dictionary<string, Action<string[]>> Actions { get; }

    public Dictionary<string, string> Variables { get; }

    public CfgScriptEvaluator(CfgScript cfg)
    {
        Cfg = cfg;
        Variables = new();
        Actions = new();
    }

    public void Run()
    {
        foreach (var entry in Enumerate())
        {
            var key = entry.Key;
            var args = entry.Args;
            Actions[key](args);
        }
    }

    string Evaluate(string value)
    {
        if (value.StartsWith('$'))
        {
            Evaluate(Variables[value.Substring(1)]);
        }
        return value;
    }

    public IEnumerable<CfgScript.Entry> Enumerate()
    {
        foreach (var entry in Cfg.Entries)
        {
            var key = entry.Key;
            var args = entry.Args;

            var eargs = new string[args.Length];
            for (int i = 0; i < eargs.Length; i++)
            {
                eargs[i] = Evaluate(args[i]);
            }

            if (key == "var")
            {
                Variables[eargs[0]] = eargs[1];
                continue;
            }
            yield return new CfgScript.Entry(entry.Line, key, eargs);
        }
        yield break;
    }
}
