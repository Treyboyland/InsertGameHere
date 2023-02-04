using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Direction-", menuName = "Game System/Direction")]
public class DirectionSO : ScriptableObject
{
    [SerializeField]
    string directionName;
}
