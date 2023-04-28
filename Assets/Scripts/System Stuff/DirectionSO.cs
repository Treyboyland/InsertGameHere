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

    [Tooltip("Opposite direction of this direction")]
    [SerializeField]
    DirectionSO opposite;

    [Tooltip("90 degrees left of this direction")]
    [SerializeField]
    DirectionSO left;

    [Tooltip("90 degrees right of this direction")]
    [SerializeField]
    DirectionSO right;

    public Vector2 NormalizedVector
    {
        get
        {
            return vector.normalized;
        }
    }

    public float RotationFromNorth { get => rotationFromNorth; }
    public DirectionSO Opposite { get => opposite; }
    public DirectionSO Left { get => left; }
    public DirectionSO Right { get => right; }
}
