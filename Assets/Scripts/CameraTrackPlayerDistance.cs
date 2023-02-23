using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrackPlayerDistance : MonoBehaviour
{
    [SerializeField]
    float distance;

    [SerializeField]
    Player player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SetDistance();
    }

    void SetDistance()
    {
        var playerPos = player.transform.position;
        playerPos.z = transform.position.z;
        var playerDistance = Vector3.Distance(transform.position, playerPos);
        if (playerDistance > distance)
        {
            var vector = (playerPos - transform.position).normalized;
            vector *= (playerDistance - distance);
            transform.position += vector;
        }
    }
}
