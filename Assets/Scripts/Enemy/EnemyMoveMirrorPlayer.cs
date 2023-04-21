using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveMirrorPlayer : EnemyMove
{
    [SerializeField]
    RuntimeRoomDictionary roomDictionary;

    [SerializeField]
    Animator animator;

    static PlayerSpriteController playerAnimator;

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

    void GetPlayerAnimator()
    {
        if (!playerAnimator)
        {
            playerAnimator = player.GetComponent<PlayerSpriteController>();
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

            SetDirection();
        }
    }

    void SetDirection()
    {
        GetPlayerAnimator();
        if (!playerAnimator || !animator)
        {
            Debug.LogWarning(playerAnimator + " " + animator);
            return;
        }

        bool up = playerAnimator.Animator.GetBool(PlayerSpriteController.UP);
        bool down = playerAnimator.Animator.GetBool(PlayerSpriteController.DOWN);
        bool left = playerAnimator.Animator.GetBool(PlayerSpriteController.LEFT);
        bool right = playerAnimator.Animator.GetBool(PlayerSpriteController.RIGHT);
        if (up)
        {
            animator.SetBool(PlayerSpriteController.UP, false);
            animator.SetBool(PlayerSpriteController.DOWN, true);
            animator.SetBool(PlayerSpriteController.LEFT, false);
            animator.SetBool(PlayerSpriteController.RIGHT, false);
        }
        else if (down)
        {
            animator.SetBool(PlayerSpriteController.UP, true);
            animator.SetBool(PlayerSpriteController.DOWN, false);
            animator.SetBool(PlayerSpriteController.LEFT, false);
            animator.SetBool(PlayerSpriteController.RIGHT, false);
        }
        else if (left)
        {
            animator.SetBool(PlayerSpriteController.UP, false);
            animator.SetBool(PlayerSpriteController.DOWN, false);
            animator.SetBool(PlayerSpriteController.LEFT, false);
            animator.SetBool(PlayerSpriteController.RIGHT, true);
        }
        else if (right)
        {
            animator.SetBool(PlayerSpriteController.UP, false);
            animator.SetBool(PlayerSpriteController.DOWN, false);
            animator.SetBool(PlayerSpriteController.LEFT, true);
            animator.SetBool(PlayerSpriteController.RIGHT, false);
        }
    }
}
