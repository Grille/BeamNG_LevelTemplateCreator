namespace Grille.BeamNgLib.IO;

public class LevelInfoSerializer
{
    public static void Save(string path, Level level)
    {
        using var stream = new FileStream(path, FileMode.Create);
        Serialize(stream, level);
    }

    public static void Serialize(Stream stream, Level level)
    {
        var dict = new JsonDict()
        {
            ["defaultSpawnPointName"] = "spawn_default",

            ["size"] = new[] { level.Terrain.WorldSize, level.Terrain.WorldSize },
            ["previews"] = new[] { "preview.png" },

            ["spawnPoints"] = new JsonDict[]
            {
                new()
                {
                    ["name"] = "Default",
                    ["objectname"] = "spawn_default",
                    ["preview"] = "preview.jpg",
                }
            }
        };

        level.Info.Serialize(dict);

        JsonDictSerializer.Serialize(stream, dict, true);
    }
}
