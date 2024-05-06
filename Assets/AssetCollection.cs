using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelTemplateCreator.Assets;

internal class AssetCollection<T> : ICollection<T> where T : Asset
{
    Dictionary<string, T> assets = new Dictionary<string, T>();

    public int Count => assets.Count;

    public bool IsReadOnly => false;

    public void Add(T item)
    {
        assets[item.Name] = item;
    }

    public void Clear()
    {
        assets.Clear();
    }

    public T this[string key] => assets[key];


    public bool ConatinsKey(string key) => assets.ContainsKey(key);

    public bool TryGetValue(string key, out T value)
    {
        return assets.TryGetValue(key, out value!);
    }

    public bool Contains(T item)
    {
        return assets.ContainsKey(item.Name);
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        assets.Values.CopyTo(array, arrayIndex);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return assets.Values.GetEnumerator();
    }

    public bool Remove(T item)
    {
        return assets.Remove(item.Name);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return assets.Values.GetEnumerator();
    }
}
