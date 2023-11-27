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

    [SerializeField]
    ThemeObjectTypeSO doorType;

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

    public bool IsDoor(ThemeObjectTypeSO theme)
    {
        return theme == doorType;
    }
}
