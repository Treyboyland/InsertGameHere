using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    /// <summary>
    /// Creates a shallow copy of the given items
    /// </summary>
    /// <param name="list"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static List<T> CloneList<T>(this IEnumerable<T> list)
    {
        List<T> temp = new List<T>();
        foreach (var item in list)
        {
            temp.Add(item);
        }

        return temp;
    }

    /// <summary>
    /// Waits for the given state. Assumes on the 0th layer
    /// </summary>
    /// <param name="animator"></param>
    /// <param name="state"></param>
    /// <returns></returns>
    public static IEnumerator WaitForState(this Animator animator, string state)
    {
        while (!animator.GetCurrentAnimatorStateInfo(0).IsName(state))
        {
            yield return null;
        }
    }

    public static int Sum(this IEnumerable<int> list)
    {
        int total = 0;
        foreach (var item in list)
        {
            total += item;
        }

        return total;
    }

    public static float Sum(this IEnumerable<float> list)
    {
        float total = 0;
        foreach (var item in list)
        {
            total += item;
        }

        return total;
    }

    /// <summary>
    /// Returns a number between the given vector's
    /// x (inclusive) and y (exclusive)
    /// </summary>
    /// <param name="vector"></param>
    /// <returns></returns>
    public static int RandomInt(this Vector2Int vector)
    {
        return Random.Range(vector.x, vector.y);
    }

    public static DropTableSO.ItemWeight GetItem(this List<DropTableSO.ItemWeight> itemWeight)
    {
        int total = itemWeight.Select(x => x.Weight).Sum();
        int current = 0;
        int randomValue = UnityEngine.Random.Range(0, total);

        foreach (var item in itemWeight)
        {
            current += item.Weight;
            if (randomValue < current)
            {
                return item;
            }
        }

        return itemWeight[itemWeight.Count - 1];
    }
}
