using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveMirrorPlayer : EnemyMove
{
    [SerializeField]
    RuntimeRoomDictionary roomDictionary;

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        if (ShouldPerformAction())
        {
            Move();
        }
    }

    void Move()
    {
        if (roomDictionary.ContainsKey(enemy.CurrentRoom))
        {
            var room = roomDictionary[enemy.CurrentRoom];
            var distance = player.transform.position - room.transform.position;
            distance.x *= -1;
            distance.y *= -1;

            transform.position = room.transform.position + distance;
        }
    }
}
