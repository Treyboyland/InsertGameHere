using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField]
    GameObject prefab;

    [SerializeField]
    int numInitial;

    List<GameObject> pool = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {

    }

    GameObject CreateObject()
    {
        var newObject = Instantiate(prefab, transform);
        newObject.SetActive(false);
        pool.Add(newObject);
        return newObject;
    }

    public GameObject GetObject()
    {
        foreach (var obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }

        return CreateObject();
    }

    public void DisableAll()
    {
        foreach (var obj in pool)
        {
            obj.SetActive(false);
        }
    }
}
