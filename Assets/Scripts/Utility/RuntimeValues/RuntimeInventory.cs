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

    private void ChangeItemCount_NoInvoke(ItemSO item, int amount)
    {
        var newAmount = Mathf.Max(0, (_dict.ContainsKey(item) ? _dict[item] : 0) + amount);

        if (newAmount > 0 && item.IsKeyItem)
        {
            newAmount = 1;
        }

        _dict[item] = newAmount;
    }

    public void ChangeItemCount(ItemSO item, int amount)
    {
        ChangeItemCount_NoInvoke(item, amount);
        Changed?.Invoke();
    }

    public void ChangeItemCounts(ICollection<KeyValuePair<ItemSO, int>> newItemCounts)
    {
        newItemCounts.ToList().ForEach(pair => ChangeItemCount_NoInvoke(pair.Key, pair.Value));
        Changed?.Invoke();
    }

    public void Clear() => _dict.Clear();
}
