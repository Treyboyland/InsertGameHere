using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DamagePlayerOnCollision : MonoBehaviour
{
    [SerializeField] int _damageAmount = 1;

    [SerializeField] bool instaKill;

    public UnityEvent OnHitPlayer;

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        CheckForPlayer(other.gameObject.GetComponent<Player>());
    }

    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    private void OnCollisionEnter2D(Collision2D other)
    {
        CheckForPlayer(other.gameObject.GetComponent<Player>());
    }

    void CheckForPlayer(Player player)
    {
        if (player)
        {
            OnHitPlayer.Invoke();
            if (instaKill)
            {
                player.Kill();
            }
            else
            {
                player.Damage(_damageAmount);
            }
        }
    }
}
