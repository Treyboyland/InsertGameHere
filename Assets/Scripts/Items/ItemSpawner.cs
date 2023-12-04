using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    static ItemSpawner _instance;

    public static ItemSpawner Instance => _instance;

    Dictionary<GameObject, List<GameObject>> pool = new Dictionary<GameObject, List<GameObject>>();

    private void Awake()
    {
        if (_instance != null && this != Instance)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
    }

    GameObject CreateItem(GameObject prefab)
    {
        var newItem = Instantiate(prefab);

        if (!pool.ContainsKey(prefab))
        {
            pool.Add(prefab, new List<GameObject>());
        }

        newItem.SetActive(false);

        
        pool[prefab].Add(newItem);

        return newItem;
    }

    public GameObject SpawnItem(GameObject prefab)
    {
        if (!pool.ContainsKey(prefab))
        {
            return CreateItem(prefab);
        }

        foreach (var obj in pool[prefab])
        {
            if (obj != null && !obj.activeInHierarchy)
            {
                return obj;
            }
        }

        return CreateItem(prefab);
    }

    public void DisableAllObjects()
    {
        foreach(var pair in pool)
        {
            foreach(var obj in pair.Value)
            {
                if(obj != null && obj.activeInHierarchy)
                {
                    obj.SetActive(false);
                }
            }
        }
    }
}
