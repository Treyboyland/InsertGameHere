using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "OwnerTypeSO", menuName = "Game/Owner")]
public class OwnerTypeSO : ScriptableObject
{
    [Tooltip("Name of the owner of this type")]
    [SerializeField]
    string ownerName;

    public string OwnerName { get => ownerName; }
}
