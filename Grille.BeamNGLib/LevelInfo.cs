using Grille.BeamNG.SceneTree;
using System.Drawing;

namespace Grille.BeamNG;

public class LevelInfo : JsonDictWrapper
{
    public JsonDictProperty<string> DefaultSpawnPointName { get; }

    public JsonDictProperty<string> Title { get; }

    public JsonDictProperty<string> Description { get; }

    public JsonDictProperty<string> Authors { get; }

    public JsonDictProperty<Vector2> Size { get; }

    public JsonDictProperty<string[]> Previews { get; }

    public LevelInfo(JsonDict json) : base(json)
    {
        DefaultSpawnPointName = new(this, "defaultSpawnPointName");
        Title = new(this, "title");
        Description = new(this, "description");
        Authors = new(this, "authors");
        Size = new(this, "size");
        Previews = new(this, "previews");
    }

    public LevelInfo() : this(new JsonDict())
    {
        DefaultSpawnPointName.Value = "spawn_default";
        Title.Value = "New Level";
        Description.Value = string.Empty;
        Authors.Value = Environment.UserName;
        Previews.Value = ["preview.png"];
        Size.Value = Vector2.Zero;

        var spawn = new JsonDict
        {
            ["name"] = "Default",
            ["objectname"] = "spawn_default",
            ["preview"] = "preview.jpg",
        };

        this["spawnPoints"] = new JsonDict[] { spawn };
    }
}