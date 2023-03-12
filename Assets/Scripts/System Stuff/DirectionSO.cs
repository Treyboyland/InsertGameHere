using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Direction-", menuName = "Game System/Direction")]
public class DirectionSO : ScriptableObject
{
    [SerializeField]
    string directionName;

    [Tooltip("Vector Representation of this direction")]
    [SerializeField]
    Vector2 vector;

    [Tooltip("Rotation, in degrees, of this direction from North (Up)")]
    [SerializeField]
    float rotationFromNorth;

    public Vector2 NormalizedVector
    {
        get
        {
            return vector.normalized;
        }
    }

    public float RotationFromNorth { get => rotationFromNorth; }
}
