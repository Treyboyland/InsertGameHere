using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField]
    RuntimeRoomDictionary roomDictionary;

    [SerializeField]
    RuntimeGameObject playerRef;
    Player player { get => playerRef.Value.GetComponent<Player>(); }

    [SerializeField]
    float secondsToMove;

    public void MoveToPlayerPosition()
    {
        StopAllCoroutines();
        var room = roomDictionary.GetRoomAtLocation(player.CurrentRoomLocation);

        if (room != null)
        {
            StartCoroutine(MoveToLocationOverTime(room.CenterPlayerSpawn.transform.position));
        }
    }

    public void SetToPlayerPosition()
    {
        StopAllCoroutines();
        var room = roomDictionary.GetRoomAtLocation(player.CurrentRoomLocation);

        if (room != null)
        {
            var pos = room.CenterPlayerSpawn.transform.position;
            pos.z = transform.position.z;
            transform.position = pos;
        }
    }


    IEnumerator MoveToLocationOverTime(Vector3 position)
    {
        float elapsed = 0;
        var start = transform.position;
        position.z = start.z;

        while (elapsed < secondsToMove)
        {
            elapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(start, position, elapsed / secondsToMove);
            yield return null;
        }

        transform.position = position;
    }
}
