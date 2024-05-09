namespace Grille.BeamNgLib;

public class LevelInfo
{
    public string Title { get; set; }

    public string Description { get; set; }

    public string Authors { get; set; }

    public LevelInfo()
    {
        Title = "New Level";
        Description = string.Empty;
        Authors = Environment.UserName;
    }

    public void Serialize(JsonDict dict)
    {
        dict["title"] = Title;
        dict["description"] = Description;
        dict["authors"] = Authors;
    }

}
