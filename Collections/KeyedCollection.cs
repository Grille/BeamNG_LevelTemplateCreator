using LevelTemplateCreator.Assets;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LevelTemplateCreator.Collections;

internal class KeyedCollection<T> : ICollection<T> where T : class, IKeyed
{
    readonly Dictionary<string, T> _dict;

    public KeyedCollection()
    {
        _dict = new Dictionary<string, T>();
    }

    public int Count => _dict.Count;

    public bool IsReadOnly => false;

    public Dictionary<string, T>.KeyCollection Keys => _dict.Keys;

    string GetKey(T item)
    {
        string? key = item.Key;
        if (string.IsNullOrEmpty(key))
        {
            throw new ArgumentException($"Item has no key.");
        }
        return key;
    }

    public void Add(T item)
    {
        var key = GetKey(item);

        if (TryGetValue(key, out T old))
        {
            if (old == item)
            {
                return;
            }
            throw new ArgumentException($"A item with the key '{key}' is already in the collection.");
        }
        _dict[key] = item;
    }

    public void Add(params T[] items)
    {
        foreach (var item in items)
        {
            Add(item);
        }
    }

    public bool TryGetValue(string key, out T value)
    {
        return _dict.TryGetValue(key, out value!);
    }

    public void Clear()
    {
        _dict.Clear();
    }

    public bool ContainsKey(string key) => _dict.ContainsKey(key);

    public bool Contains(T item)
    {
        var key = GetKey(item);
        return _dict.ContainsKey(key);
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        _dict.Values.CopyTo(array, arrayIndex);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return _dict.Values.GetEnumerator();
    }

    public bool Remove(T item)
    {
        var key = GetKey(item);

        if (!_dict.Remove(key, out var value))
            return false;

        if (item != value)
            throw new ArgumentException();

        return true;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
