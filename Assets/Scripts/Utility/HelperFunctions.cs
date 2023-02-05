using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HelperFunctions
{
    public static void Shuffle<T>(this List<T> list)
    {
        if (list.Count < 1)
        {
            return;
        }

        for (int i = 0; i < list.Count; i++)
        {
            int chosenIndex = Random.Range(i, list.Count);
            var temp = list[i];
            list[i] = list[chosenIndex];
            list[chosenIndex] = temp;
        }
    }

    public static T RandomItem<T>(this List<T> list)
    {
        int index = Random.Range(0, list.Count);
        return list[index];
    }
}
