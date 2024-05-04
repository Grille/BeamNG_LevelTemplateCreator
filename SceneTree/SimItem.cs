using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using LevelTemplateCreator.IO;

namespace LevelTemplateCreator.SceneTree;

internal class SimItem
{
    public Dictionary<string, object> Dict { get; set; }

    public SimItem()
    {
        Dict = new Dictionary<string, object>();
    }

    public object this[string key]
    {
        get => Dict[key];
        set => Dict[key] = value;
    }

    public string Class {
        get => (string)this["class"];
        set => this["class"] = value;
    }

    public string Name
    {
        get => (string)this["name"];
        set => this["name"] = value;
    }

    public string InternalName
    {
        get => (string)this["internalName"];
        set => this["internalName"] = value;
    }

    public string PersistentId
    {
        get => (string)this["persistentId"];
        set => this["persistentId"] = value;
    }

    public Vector3 Position { get => GetVec3("position"); set => SetVec3("position", value); }

    public void SetParent(SimGroup? parent)
    {
        const string key = "__parent";

        if (parent == null)
        {
            Dict.Remove(key);
            return;
        }

        this[key] = parent.Name;
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
        if (Dict.TryGetValue(key, out var obj)){
            value = (T)obj;
            return true;
        }
        value = default!;
        return false;
    }

    public void SetVec2(string key, Vector2 vec)
    {
        if (TryGetValue<float[]>(key, out var array)) {
            array[0] = vec.X; array[1] = vec.Y;
        }
        {
            var newarray = new float[2] { vec.X, vec.Y };
            this[key] = newarray;
        }
    }

    public Vector2 GetVec2(string key)
    {
        var array = (float[])this[key];
        return new Vector2(array[0], array[1]);
    }

    public void SetVec3(string key, Vector3 vec)
    {
        if (TryGetValue<float[]>(key, out var array))
        {
            array[0] = vec.X; array[1] = vec.Y; array[2] = vec.Z;
        }
        {
            var newarray = new float[3] { vec.X, vec.Y, vec.Z };
            this[key] = newarray;
        }
    }

    public Vector3 GetVec3(string key)
    {
        var array = (float[])this[key];
        return new Vector3(array[0], array[1], array[2]);
    }

    public virtual void CopyTo(SimItem target)
    {
        if (target.Class != null && target.Class != Class)
            throw new ArgumentException();

        foreach (var pair in Dict)
        {
            target[pair.Key] = pair.Value;
        }
    }
}
