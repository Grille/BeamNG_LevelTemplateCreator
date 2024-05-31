using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTemplateCreator.Scripting;

public class CfgScript
{
    public List<Entry> Entries { get; }

    public record Entry(int Line, string Key, string[] Args);

    public CfgScript()
    {
        Entries = new();
    }

    public void Parse(Stream stream)
    {
        using var tr = new StreamReader(stream, leaveOpen: true);
        int lineNr = 1;
        while (true)
        {
            var rawline = tr.ReadLine();
            if (rawline == null)
                break;

            var line = rawline.Trim();
            if (line == string.Empty)
                continue;

            if (line.StartsWith('#'))
                continue;

            (var key, var args) = ParseLine(line);
            var entry = new Entry(lineNr, key, args);
            Entries.Add(entry);

            lineNr += 1;
        }
    }

    (string Key, string[] Args) ParseLine(string line)
    {
        var key = string.Empty;
        var args = Array.Empty<string>();

        void split(char seperator, int remove = 0)
        {
            var split = line.Split(seperator, 2);
            key = split[0].Trim();
            args = [split[1].Substring(0, split[1].Length - remove).Trim()];
        }

        if (line.StartsWith('$'))
        {
            split(' ');
            args = [key.Substring(1), args[0]];
            key = "var";
        }
        else if (line.Contains('<'))
        {
            split('<', 1);
        }
        else if (line.Contains('('))
        {
            split('(', 1);
            var s = args[0].Split(',');
            args = new string[s.Length];
            for (int i = 0; i< args.Length; i++)
            {
                args[i] = s[i].Trim();
            }
        }
        else
        {
            key = line;
        }

        return (key, args);
    }
}
