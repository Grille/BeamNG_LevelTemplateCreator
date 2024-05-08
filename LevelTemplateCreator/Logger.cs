using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTemplateCreator;

enum LoggerColor
{
    Default = ConsoleColor.Gray,
    Red = ConsoleColor.Red,
}

internal static class Logger
{
    public static void WriteLine() {
        Console.WriteLine();
    }

    public static void WriteLine(string text)
    {
        Console.WriteLine(text);
    }

    public static void WriteLine(string text, LoggerColor color)
    {
        Console.ForegroundColor = (ConsoleColor)color;
        Console.WriteLine(text);
        Console.ForegroundColor = (ConsoleColor)LoggerColor.Default;
    }

    public static void Error()
    {

    }
}
