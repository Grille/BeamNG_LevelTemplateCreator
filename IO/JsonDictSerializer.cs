using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LevelTemplateCreator.IO;

static class JsonDictSerializer
{
    public static void Serialize<T>(Stream stream, T value, bool intended = false) where T : IDictionary<string, object>
    {
        var options = new JsonSerializerOptions()
        {
            WriteIndented = intended,
        };
        JsonSerializer.Serialize(stream, value, options);
    }

    public static Dictionary<string, object> Deserialize(Stream stream) => Deserialize<Dictionary<string, object>>(stream);

    public static T Deserialize<T>(Stream stream) where T : IDictionary<string, object>, new()
    {
        var result = new T();
        Deserialize(stream, result);
        return result;
    }

    public static void Deserialize<T>(Stream stream, T dst) where T : IDictionary<string, object>
    {
        var options = new JsonSerializerOptions()
        {
            ReadCommentHandling = JsonCommentHandling.Skip,
            AllowTrailingCommas = true,
        };
        var json = JsonSerializer.Deserialize<JsonElement>(stream, options);

        if (json.ValueKind == JsonValueKind.Object)
        {
            GetDict(json, dst);
        }
        else if (json.ValueKind == JsonValueKind.Array)
        {
            dst["class"] = "Template_Array";
            dst["items"] = GetArray(json);
        }
        else
        {
            throw new Exception();
        }
    }

    public static object? GetValue(JsonElement json)
    {
        object value = json.ValueKind switch
        {
            JsonValueKind.String => json.ToString(),
            JsonValueKind.Number => json.GetSingle(),
            JsonValueKind.Array => GetArray(json),
            JsonValueKind.True => json.GetBoolean(),
            JsonValueKind.False => json.GetBoolean(),
            JsonValueKind.Null => null!,
            _ => throw new Exception("Unexpected type " + json.ValueKind)
        };

        return value;

    }

    public static object GetArray(JsonElement json)
    {
        int count = json.GetArrayLength();
        if (count == 0)
            throw new Exception();

        var first = json[0];

        if (first.ValueKind == JsonValueKind.Object)
        {
            var objarray = new Dictionary<string, object>[count];

            for (int i = 0; i < count; i++)
            {
                objarray[i] = GetDict(json[i]);
            }

            return objarray;
        }

        Array? array = first.ValueKind switch
        {
            JsonValueKind.Number => json.Deserialize<float[]>(),
            _ => throw new Exception(),
        };

        if (array == null)
            throw new Exception();

        return array;
    }

    public static Dictionary<string, object> GetDict(JsonElement json)
    {
        var result = new Dictionary<string, object>();
        GetDict(json, result);
        return result;
    }

    public static void GetDict<T>(JsonElement json, T dst) where T : IDictionary<string, object>
    {
        var jdict = json.Deserialize<Dictionary<string, JsonElement>>();
        if (jdict == null)
            throw new Exception();

        var result = dst;

        foreach (var jelement in jdict)
        {
            var key = jelement.Key;
            object? value = GetValue(jelement.Value);

            if (value != null)
            {
                result[key] = value;
            }
        }
    }

}
