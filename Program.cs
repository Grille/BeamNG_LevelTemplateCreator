using LevelTemplateCreator.SceneTree;
using System.IO.Compression;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LevelTemplateCreator
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());


            //var zip = ZipFile.Open("",ZipArchiveMode.Read);

            //var entry = zip.GetEntry("fg");
        }
    }
}