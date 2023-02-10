using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Vector2List
{
    public List<Vector2> Items;

    public static implicit operator List<Vector2>(Vector2List list)
    {
        return list.Items;
    }
}

[Serializable]
public class TransformLocalList
{
    public List<Transform> Transforms;

    public static implicit operator List<Vector2>(TransformLocalList list)
    {
        List<Vector2> pos = new List<Vector2>();

        foreach (var transform in list.Transforms)
        {
            pos.Add(transform.localPosition);
        }

        return pos;
    }
}