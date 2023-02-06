using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomThemeSetter : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer spriteRenderer;

    [SerializeField]
    bool isBackground;

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

    void UpdateTheme(RoomThemeSO themeData)
    {
        spriteRenderer.sprite = isBackground ? themeData.Background : themeData.Wall;
    }
}
