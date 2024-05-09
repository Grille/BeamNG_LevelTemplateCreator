using Grille.BeamNgLib.Collections;
using System.Runtime.CompilerServices;

namespace Grille.BeamNgLib.SceneTree;

struct JsonDictProperty
{
    public readonly JsonDictWrapper Owner;
    public readonly string Key;

    public JsonDictProperty(JsonDictWrapper owner, string key)
    {
        Owner = owner;
        Key = key;
    }

    public object Value { get => Owner[Key]; set => Owner[Key] = value; }

    public bool Exists => Owner.Dict.ContainsKey(Key);

    public void Remove() => Owner.Dict.Remove(Key);

    public void Vector2(Vector2 vec)
    {
        if (Owner.TryGetValue<float[]>(Key, out var array))
        {
            array[0] = vec.X; array[1] = vec.Y;
        }
        {
            var newarray = new float[2] { vec.X, vec.Y };
            Value = newarray;
        }
    }

    public Vector2 Vector2()
    {
        var array = (float[])Value;
        return new Vector2(array[0], array[1]);
    }

    public void Vector3(Vector3 vec)
    {
        if (Owner.TryGetValue<float[]>(Key, out var array))
        {
            array[0] = vec.X; array[1] = vec.Y; array[2] = vec.Z;
        }
        {
            var newarray = new float[3] { vec.X, vec.Y, vec.Z };
            Value = newarray;
        }
    }

    public Vector3 Vector3()
    {
        var array = (float[])Value;
        return new Vector3(array[0], array[1], array[2]);
    }

    public void Single(float value)
    {
        Value = value;
    }

    public float Single()
    {
        return (float)Value;
    }
}

public class JsonDictProperty<T> :  IKeyed where T : notnull
{
    enum PropertyType
    {
        Object,
        Float,
        Int,
        Vec2,
        Vec3,
    }

    JsonDictProperty _property;
    PropertyType _type;

    public bool Exists => _property.Exists;

    public T? DefaultValue { get; }

    public T Value { get => Get(); set => Set(value); }

    public string Key => _property.Key;

    public JsonDictProperty(JsonDictWrapper owner, string key)
    {
        _property = new JsonDictProperty(owner, key);

        var t = typeof(T);
        if (t == typeof(float))
            _type = PropertyType.Float;
        else if (t == typeof(int))
            _type = PropertyType.Int;
        else if (t == typeof(Vector2))
            _type = PropertyType.Vec2;
        else if (t == typeof(Vector3))
            _type = PropertyType.Vec3;
        else
            _type = PropertyType.Object;
    }

    public JsonDictProperty(JsonDictWrapper owner, string key, T defaultValue) : this(owner, key)
    {
        DefaultValue = defaultValue;
    }

    public void Remove() => _property.Remove();

    public void Set(T value)
    {
        switch (_type)
        {
            case PropertyType.Float:
            {
                _property.Single(Unsafe.As<T, float>(ref value));
                break;
            }
            case PropertyType.Int:
            {
                _property.Single(Unsafe.As<T, int>(ref value));
                break;
            }
            case PropertyType.Vec2:
            {
                _property.Vector2(Unsafe.As<T, Vector2>(ref value));
                break;
            }
            case PropertyType.Vec3:
            {
                _property.Vector3(Unsafe.As<T, Vector3>(ref value));
                break;
            }
            default:
                _property.Value = value;
                break;
        }
    }

    public T Get()
    {
        if (!_property.Exists)
        {
            if (DefaultValue != null)
            {
                return DefaultValue;
            }
            var msg = $"Failed to acces property '{_property.Key}' of type '{typeof(T).FullName}'.";
            throw new InvalidOperationException(msg);
        }

        switch (_type)
        {
            case PropertyType.Float:
            {
                var value = _property.Single();
                return Unsafe.As<float, T>(ref value);
            }
            case PropertyType.Int:
            {
                var value = (int)_property.Single();
                return Unsafe.As<int, T>(ref value);
            }
            case PropertyType.Vec2:
            {
                var value = _property.Vector2();
                return Unsafe.As<Vector2, T>(ref value);
            }
            case PropertyType.Vec3:
            {
                var value = _property.Vector3();
                return Unsafe.As<Vector3, T>(ref value);
            }
            default:
                return (T)_property.Value;
        }

    }

    public void SetIfEmpty(T value)
    {
        if (!Exists)
        {
            Set(value);
        }
    }

    public override string? ToString() => Value.ToString();
}