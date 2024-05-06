using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LevelTemplateCreator.IO;

static class LevelInfoSerializer
{
    public static void Serialize(Level level, string path)
    {
        using var stream = new FileStream(path, FileMode.Create);
        Serialize(level, stream);
    }

    public static void Serialize(Level level, Stream stream)
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
