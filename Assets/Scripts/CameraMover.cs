using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField]
    Camera mainCamera;

    [SerializeField]
    RuntimeRoomDictionary roomDictionary;

    [SerializeField]
    Player player;

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
            pos.z = mainCamera.transform.position.z;
            mainCamera.transform.position = pos;
        }
    }


    IEnumerator MoveToLocationOverTime(Vector3 position)
    {
        float elapsed = 0;
        var start = mainCamera.transform.position;
        position.z = start.z;

        while (elapsed < secondsToMove)
        {
            elapsed += Time.deltaTime;
            mainCamera.transform.position = Vector3.Lerp(start, position, elapsed / secondsToMove);
            yield return null;
        }

        mainCamera.transform.position = position;
    }
}
