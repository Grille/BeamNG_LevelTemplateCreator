using Grille.BeamNG.Collections;
using Grille.BeamNG.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Grille.BeamNG.IO;
public static class BeamEnvironment
{
    public class Product
    {
        const string NullVersion = "0.0.0";
        const string SteamGameDir = "C:\\Program Files (x86)\\Steam\\steamapps\\common\\BeamNG.drive";

        public string Name { get; }

        /// <summary>...user\AppData\Local\BeamNG\BeamNG.drive\current</summary>
        public string UserCurrentDirectory { get; private set; } = default!;

        /// <summary>...\user\AppData\Local\BeamNG</summary>
        public string UserRootDirectory { get; private set; } = default!;

        /// <summary>0.38.3.0</summary>
        public string GameVersion { get; private set; } = default!;

        /// <summary>...\steamapps\common\BeamNG.drive</summary>
        public string GameDirectory { get; private set; } = default!;

        public Product(string name = "drive")
        {
            Name = name;
        }

        [MemberNotNullWhen(true, nameof(GameDirectory))]
        public bool IsGameDirectoryValid()
        {
            if (GameDirectory == null)
                return false;

            if (!Directory.Exists(GameDirectory))
                return false;

            var exePath = Path.Combine(GameDirectory, $"BeamNG.{Name}.exe");

            if (!File.Exists(exePath))
                return false;

            return true;
        }

        public record IniInfo(string Version, string InstallPath);

        public static IniInfo LoadIni(string filePath)
        {
            var ini = IniDictSerializer.Load(filePath);

            return new IniInfo(
                ini.TryGetValue<string>("version", out var version) ? version : NullVersion,
                ini.TryGetValue<string>("installPath", out var path) ? path : SteamGameDir
            );
        }

        public void LoadIni()
        {
            var ini = LoadIni(Path.Join(UserRootDirectory, $"BeamNG.{Name}.ini"));
            GameVersion = ini.Version;
            GameDirectory = ini.InstallPath;
        }

        public void Update(string? userDir, string? gameDir = null)
        {
            if (userDir != null)
            {
                UserRootDirectory = userDir;
                UserCurrentDirectory = Path.Combine(UserRootDirectory, $"BeamNG.{Name}/current");

                try
                {
                    LoadIni();
                }
                catch (Exception ex)
                {
                    Logger.WriteLine($"Failed to load BeamNG.{Name}.ini: {ex.Message}");
                }
            }
            if (gameDir != null)
            {
                GameDirectory = gameDir;
            }
        }
    }

    public static Product Drive { get; }

    public static Product Tech { get; }

    static BeamEnvironment()
    {
        Drive = new Product("drive");
        Tech = new Product("tech");
    }
}
 