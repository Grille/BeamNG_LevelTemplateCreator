using Grille.BeamNgLib.Logging;
using Grille.BeamNgLib.SceneTree;
using System.Globalization;
using System.Threading;

namespace LevelTemplateCreator;

internal static class Program
{

#if DEBUG
    public const bool Debug = true;
#else
    public const bool Debug = false;
#endif

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        Logger.ConsoleOutputEnabled = true;

        using var stream = new FileStream("console.log", FileMode.Create);
        Logger.OutputStream = stream;

        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm());
    }
}