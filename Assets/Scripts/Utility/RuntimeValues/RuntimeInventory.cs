using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "RuntimeInventory", menuName = "RuntimeValues/Inventory")]
public class RuntimeInventory : ScriptableObject
{
    Dictionary<ItemSO, int> _dict = new Dictionary<ItemSO, int>();
    
    public IReadOnlyDictionary<ItemSO, int> AsDictionary() => _dict;

    public event System.Action Changed;
    public event System.Action<ItemSO, int> ItemCountChanged;

    public void ChangeItemCount(ItemSO item, int amount)
    {
        var currentCount = _dict.ContainsKey(item) ? _dict[item] : 0;
        var itemMax = item.IsKeyItem ? 1 : int.MaxValue;
        var newCount = Mathf.Clamp(currentCount + amount, 0, itemMax);
        var fixedAmount = newCount - currentCount;

        if (fixedAmount != 0)
        {
            _dict[item] = newCount;
            ItemCountChanged?.Invoke(item, fixedAmount);
            Changed?.Invoke();
        }
    }

    public void Clear()
    {
        _dict.Clear();
        Changed?.Invoke();
    }

    public int GetItemCount(ItemSO item) => _dict.ContainsKey(item) ? _dict[item] : 0;
    public bool HasItem(ItemSO item) => _dict.ContainsKey(item);
    public bool HasItems(ItemSO item, int amount) => _dict.ContainsKey(item) && _dict[item] == amount;
}
