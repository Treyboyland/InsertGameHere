using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuntimeDictionary<TKey, TValue> : ScriptableObject, IDictionary<TKey, TValue>
{
    public event System.Action Changed;

    protected Dictionary<TKey, TValue> _dict = new Dictionary<TKey, TValue>();

    public TValue this[TKey key] 
    { 
        get => ((IDictionary<TKey, TValue>)_dict)[key]; 
        set
        {
            ((IDictionary<TKey, TValue>)_dict)[key] = value; 
            Changed?.Invoke();
        }
    }

    public ICollection<TKey> Keys => ((IDictionary<TKey, TValue>)_dict).Keys;

    public ICollection<TValue> Values => ((IDictionary<TKey, TValue>)_dict).Values;

    public int Count => ((ICollection<KeyValuePair<TKey, TValue>>)_dict).Count;

    public bool IsReadOnly => ((ICollection<KeyValuePair<TKey, TValue>>)_dict).IsReadOnly;

    public void Add(TKey key, TValue value)
    {
        ((IDictionary<TKey, TValue>)_dict).Add(key, value);
        Changed?.Invoke();
    }

    public void Add(KeyValuePair<TKey, TValue> item)
    {
        ((ICollection<KeyValuePair<TKey, TValue>>)_dict).Add(item);
        Changed?.Invoke();
    }

    public void Clear()
    {
        ((ICollection<KeyValuePair<TKey, TValue>>)_dict).Clear();
        Changed?.Invoke();
    }

    public bool Contains(KeyValuePair<TKey, TValue> item)
    {
        return ((ICollection<KeyValuePair<TKey, TValue>>)_dict).Contains(item);
    }

    public bool ContainsKey(TKey key)
    {
        return ((IDictionary<TKey, TValue>)_dict).ContainsKey(key);
    }

    public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
    {
        ((ICollection<KeyValuePair<TKey, TValue>>)_dict).CopyTo(array, arrayIndex);
    }

    public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
    {
        return ((IEnumerable<KeyValuePair<TKey, TValue>>)_dict).GetEnumerator();
    }

    public bool Remove(TKey key)
    {
        var rval = ((IDictionary<TKey, TValue>)_dict).Remove(key);
        Changed?.Invoke();
        return rval;
    }

    public bool Remove(KeyValuePair<TKey, TValue> item)
    {
        var rval = ((ICollection<KeyValuePair<TKey, TValue>>)_dict).Remove(item);
        Changed?.Invoke();
        return rval;
    }

    public bool TryGetValue(TKey key, out TValue value)
    {
        return ((IDictionary<TKey, TValue>)_dict).TryGetValue(key, out value);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)_dict).GetEnumerator();
    }
}
