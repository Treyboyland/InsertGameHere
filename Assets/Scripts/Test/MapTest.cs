using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTest : MonoBehaviour
{
    [SerializeField]
    int numLevels;

    [SerializeField]
    MapConfig mapConfig;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 1; i <= numLevels; i++)
        {
            var mapData = mapConfig.GenerateMap(i);
        }
    }
}
