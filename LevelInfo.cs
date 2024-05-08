using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LevelTemplateCreator;

internal class LevelInfo
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
