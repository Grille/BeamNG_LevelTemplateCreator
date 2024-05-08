using System.Globalization;

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
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm());
    }
}