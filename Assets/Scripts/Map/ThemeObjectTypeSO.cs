using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ThemeObjectType-", menuName = "Theme/Object Type")]
public class ThemeObjectTypeSO : ScriptableObject
{
    [SerializeField]
    string objectName;

    public string ObjectName { get => objectName; set => objectName = value; }
}
