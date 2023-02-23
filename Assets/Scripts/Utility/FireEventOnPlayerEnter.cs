using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEventOnPlayerEnter : MonoBehaviour
{
    [SerializeField]
    GameEvent eventToFire;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.gameObject.GetComponent<Player>();
        FireEventIfPlayerExists(player);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var player = other.gameObject.GetComponent<Player>();
        FireEventIfPlayerExists(player);
    }

    void FireEventIfPlayerExists(Player player)
    {
        if (player && eventToFire)
        {
            eventToFire.Invoke();
        }
    }
}
