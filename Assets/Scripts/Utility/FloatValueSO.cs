using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FloatSO", menuName = "Utility/Float")]
public class FloatValueSO : ScriptableObject
{
    [SerializeField]
    float value;

    public float Value { get => value; }

    public static implicit operator float(FloatValueSO val)
    {
        return val.value;
    }
}
