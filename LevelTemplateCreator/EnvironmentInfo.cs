using Grille.BeamNG.IO;
using Grille.BeamNG.IO.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grille.BeamNG;

public static class EnvironmentInfo
{
    public class Property
    {
        string _path = string.Empty;
        public string Path { get => _path; set => SetPath(value); }

        public bool IsValid { get; private set; }

        private void SetPath(string path)
        {
            _path = path;
            IsValid = Validate(path);
        }

        protected virtual bool Validate(string path)
        {
            if (!Directory.Exists(path))
                return false;

            return true;
        }

        public void TryFindValidPath(string[] paths)
        {
            foreach (var path in paths)
            {
                SetPath(path);
                if (IsValid)
                {
                    return;
                }
            }
        }
    }

    public class PropertyGame : Property
    {
        protected override bool Validate(string path)
        {
            if (!base.Validate(path))
                return false;

            var exepath = System.IO.Path.Combine(path, "BeamNG.drive.exe");

            if (!File.Exists(exepath))
                return false;

            return true;
        }
    }

    public class PropertyUser : Property
    {
        public string LevelsPath { get; set; } = string.Empty;

        protected override bool Validate(string path)
        {
            if (!base.Validate(path))
                return false;

            var current = System.IO.Path.Combine(path, "current");
            if (!Directory.Exists(current))
                return false;

            LevelsPath = System.IO.Path.Combine(current, "levels");

            return true;
        }
    }

    static public Property Packages { get; }

    static public PropertyUser UserData { get; }

    static public PropertyGame GameData { get; }

    static public bool IsValid { get => Packages.IsValid && UserData.IsValid && GameData.IsValid; }

    static public string ConfigFilePath { get; set; }

    static public VirtualFileSystem FileSystem { get; }

    static EnvironmentInfo()
    {
        ConfigFilePath = "config.json";
        Packages = new Property();
        UserData = new PropertyUser();
        GameData = new PropertyGame();
        FileSystem = new VirtualFileSystem();
    }

    static public void TryFindInvalid()
    {
        if (!UserData.IsValid)
        {
            TryFindUserDir();
        }

        if (!GameData.IsValid)
        {
            TryFindGameDir();
        }
    }

    static public void TryFindGameDir()
    {
        GameData.TryFindValidPath(
        [
            "C:\\Program Files (x86)\\Steam\\steamapps\\common\\BeamNG.drive",
        ]);
    }

    static public void TryFindUserDir()
    {
        UserData.TryFindValidPath(
        [
            $"C:\\Users\\{Environment.UserName}\\AppData\\Local\\BeamNG\\BeamNG.drive",
        ]);
    }

    static public void Load()
    {
        if (!File.Exists(ConfigFilePath))
            return;

        using var stream = new FileStream(ConfigFilePath, FileMode.Open);
        var dict = JsonDictSerializer.Deserialize(stream);

        if (dict.TryGetValue("gamepath", out object? gamepath))
        {
            GameData.Path = (string)gamepath;
        }
        if (dict.TryGetValue("userpath", out object? userpath))
        {
            UserData.Path = (string)userpath;
        }
        if (dict.TryGetValue("packages", out object? packages))
        {
            Packages.Path = (string)packages;
        }

        InvalidateFileSystem();
    }

    public static void InvalidateFileSystem()
    {
        FileSystem.Invalidate(UserData.Path, GameData.Path);
    }

    static public void Save()
    {
        var dict = new JsonDict(){
            { "gamepath", GameData.Path },
            { "userpath", UserData.Path },
            { "packages", Packages.Path },
        };

        using var stream = new FileStream(ConfigFilePath, FileMode.Create);
        JsonDictSerializer.Serialize(stream, dict, true);
    }
}
