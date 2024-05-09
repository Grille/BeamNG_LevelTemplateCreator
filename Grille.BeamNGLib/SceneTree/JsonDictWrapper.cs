using Grille.BeamNgLib.Collections;
using Grille.BeamNgLib.IO;

namespace Grille.BeamNgLib.SceneTree;

public abstract class JsonDictWrapper : IKeyed
{
    public JsonDict Dict { get; }

    public object this[string key]
    {
        get => Dict[key];
        set => Dict[key] = value;
    }

    public JsonDictProperty<string> Class { get; }
    public JsonDictProperty<string> InternalName { get; }
    public JsonDictProperty<string> Name { get; }
    public JsonDictProperty<string> PersistentId { get; }

    string IKeyed.Key => Name.Exists ? Name.Value : string.Empty;

    public JsonDictWrapper(JsonDict dict)
    {
        Dict = dict;

        Class = new(this, "class");
        Name = new(this, "name");
        InternalName = new(this, "internalName");
        PersistentId = new(this, "persistentId");
    }

    public void Serialize(Stream stream)
    {
        JsonDictSerializer.Serialize(stream, Dict, false);
    }

    public void Deserialize(Stream stream)
    {
        JsonDictSerializer.Deserialize(stream, Dict);
    }

    public bool TryGetValue<T>(string key, out T value)
    {
        if (Dict.TryGetValue(key, out var obj))
        {
            value = (T)obj;
            return true;
        }
        value = default!;
        return false;
    }

    public bool TryPopValue<T>(string key, out T value)
    {
        if (TryGetValue(key, out value))
        {
            Dict.Remove(key);
            return true;
        }
        return false;
    }

    public void TryPopValue<T>(string key, out T value, T defaultValue)
    {
        if (!TryPopValue(key, out value))
        {
            value = defaultValue;
        }
    }

    public void ApplyNamespace(string @namespace)
    {
        if (!string.IsNullOrEmpty(@namespace))
        {
            ApplyPrefix(@namespace);
        }
    }

    public virtual void ApplyPrefix(string prefix)
    {
        if (Name.Exists)
        {
            Name.Value = prefix + Name.Value;
        }
        if (InternalName.Exists)
        {
            InternalName.Value = prefix + InternalName.Value;
        }
    }

    public JsonDict CopyDict()
    {
        var dict = new JsonDict();
        CopyDict(Dict, dict);
        return dict;
    }

    public static void CopyDict(JsonDict src, JsonDict dst)
    {

    }
}