using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    OwnerTypeSO owner;

    public OwnerTypeSO Owner { get => owner; set => owner = value; }

    [SerializeField]
    bool piercing;

    [SerializeField]
    OwnerTypeSO player, neutral, enemy;

    void PlayerCollisionCheck(Collider2D other)
    {
        
    }

    void EnemyCollisionCheck(Collider2D other)
    {

    }

    void NeutralCollisionCheck(Collider2D other)
    {

    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (owner == player)
        {

        }
    }
}
