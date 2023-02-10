using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ThemeComparator", menuName = "Theme/Theme Comparator")]
public class ThemeObjectComparator : ScriptableObject
{
    [SerializeField]
    ThemeObjectTypeSO wallType;

    [SerializeField]
    ThemeObjectTypeSO backgroundType;

    [SerializeField]
    ThemeObjectTypeSO obstacleType;

    public bool IsWall(ThemeObjectTypeSO theme)
    {
        return theme == wallType;
    }

    public bool IsBackground(ThemeObjectTypeSO theme)
    {
        return theme == backgroundType;
    }

    public bool IsObstacle(ThemeObjectTypeSO theme)
    {
        return theme == obstacleType;
    }
}
