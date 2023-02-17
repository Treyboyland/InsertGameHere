using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomThemeSetter : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer spriteRenderer;

    [SerializeField]
    ThemeObjectTypeSO objectType;

    [SerializeField]
    ThemeObjectComparator comparator;

    Room room;

    // Start is called before the first frame update
    void Awake()
    {
        room = GetComponentInParent<Room>();
        if (room)
        {
            room.OnSetTheme.AddListener(UpdateTheme);
        }
    }

    public void UpdateTheme(RoomThemeSO themeData)
    {
        if (themeData == null)
        {
            return;
        }

        if (comparator.IsBackground(objectType))
        {
            spriteRenderer.sprite = themeData.Background;
        }
        else if (comparator.IsObstacle(objectType))
        {
            spriteRenderer.sprite = themeData.Obstacle;
        }
        else if (comparator.IsWall(objectType))
        {
            spriteRenderer.sprite = themeData.Wall;
        }
    }
}
