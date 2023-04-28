using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyMove : MonoBehaviour
{
    [SerializeField]
    protected Enemy enemy;

    protected static Player player;

    public virtual bool ShouldPerformAction()
    {
        if (player == null)
        {
            player = GameObject.FindObjectOfType<Player>();
        }
        if (!player)
        {
            return false;
        }

        return player.CurrentRoomLocation == enemy.CurrentRoom;
    }
}
