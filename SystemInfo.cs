using LevelTemplateCreator.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTemplateCreator;

internal static class SystemInfo
{
    const string configpath = "config.json";

    public static string PackagesDirPath { get; set; } = "./packages";

    public static string GameDirPath { get; set; } = string.Empty;

    public static string UserDirPath { get; set; } = string.Empty;

    public static string UserDirLevelsPath { get; set; } = string.Empty;

    public static Version LatestBeamNGVersion { get; private set; } = new Version(0, 0);

    public static bool IsGameDirValid { get; private set; }

    public static bool IsUserDirValid { get; private set; }

    public static bool IsValid => IsGameDirValid && IsUserDirValid;

    public static bool IsGameDir(string path)
    {
        if (!Directory.Exists(path)) 
            return false;

        if (!File.Exists(Path.Combine(path, "BeamNG.drive.exe")))
            return false;

        return true;
    }

    public static bool IsUserDir(string path)
    {
        if (!Directory.Exists(path))
            return false;

        if (!File.Exists(Path.Combine(path, "version.txt")))
            return false;

        return true;
    }

    public static void Validate()
    {
        IsGameDirValid = IsGameDir(GameDirPath);
        IsUserDirValid = IsUserDir(UserDirPath);
    }

    public static void Update()
    {
        UpdateGameInfo();
        UpdateUserInfo();
    }

    public static void UpdateGameInfo()
    {
    } 

    public static void UpdateUserInfo()
    {
        if (!IsUserDirValid)
        {
            LatestBeamNGVersion = new Version(0, 0);
            return;
        }

        var versionpath = Path.Combine(UserDirPath, "version.txt");
        var versiontext = File.ReadAllText(versionpath);
        LatestBeamNGVersion = new Version(versiontext);

        UserDirLevelsPath = Path.Combine(UserDirPath, LatestBeamNGVersion.ToString(2), "levels");
    }

    public static void TryFindInvalid()
    {
        if (!IsGameDirValid)
        {
            TryFindGameDir();
        }

        if (!IsUserDirValid)
        {
            TryFindUserDir();
        }
    }

    public static void TryFindGameDir()
    {
        TryFindGameDir(
        [
            "C:\\Program Files (x86)\\Steam\\steamapps\\common\\BeamNG.drive",
        ]);
    }

    public static void TryFindUserDir()
    {
        TryFindUserDir(
        [
            $"C:\\Users\\{Environment.UserName}\\AppData\\Local\\BeamNG.drive",
        ]);
    }

    public static void TryFindGameDir(string[] paths)
    {
        foreach (var path in paths)
        {
            if (IsGameDir(path))
            {
                IsGameDirValid = true;
                GameDirPath = path;
                UpdateGameInfo();
                return;
            }
        }
    }

    public static void TryFindUserDir(string[] paths)
    {
        foreach (var path in paths)
        {
            if (IsUserDir(path))
            {
                IsUserDirValid = true;
                UserDirPath = path;
                UpdateUserInfo();
                return;
            }
        }
    }

    public static void Load()
    {
        if (File.Exists(configpath))
        {
            using var stream = new FileStream(configpath, FileMode.Open);
            var dict = JsonDictSerializer.Deserialize(stream);

            if (dict.TryGetValue("gamepath", out object? gamepath))
            {
                GameDirPath = (string)gamepath;
            }
            if (dict.TryGetValue("userpath", out object? userpath))
            {
                UserDirPath = (string)userpath;
            }
            if (dict.TryGetValue("packages", out object? packages))
            {
                PackagesDirPath = (string)packages;
            }
        }

        Validate();
        Update();
    }

    public static void Save()
    {
        var dict = new Dictionary<string, object>(){
            { "gamepath", GameDirPath },
            { "userpath", UserDirPath },
            { "packages", PackagesDirPath },
        };

        using var stream = new FileStream(configpath, FileMode.Create);
        JsonDictSerializer.Serialize(stream, dict, true);
    }
}
