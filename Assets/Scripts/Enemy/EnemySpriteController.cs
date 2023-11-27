using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpriteController : MonoBehaviour
{
    /*
     This whole class probably could have been the Player Sprite controller...
    */

    [SerializeField]
    Animator animator;

    [SerializeField]
    Rigidbody2D body;

    [SerializeField]
    float maxNormal;

    public readonly List<string> DirectionTriggers = new List<string>() { UP, DOWN, LEFT, RIGHT };

    public const string UP = "Up";
    public const string DOWN = "Down";
    public const string LEFT = "Left";
    public const string RIGHT = "Right";

    // Update is called once per frame
    void Update()
    {
        SetParameters();
    }

    void SetParameters()
    {
        bool stopped = body.velocity == Vector2.zero;
        animator.SetBool("Idle", stopped);
        if (stopped)
        {
            return;
        }

        bool vertGreater = Mathf.Abs(body.velocity.x) < Mathf.Abs(body.velocity.y);
        bool positive;

        if (vertGreater)
        {
            positive = body.velocity.y >= 0;
        }
        else
        {
            positive = body.velocity.x >= 0;
        }

        float xSpeed = Mathf.Abs(body.velocity.x);
        float ySpeed = Mathf.Abs(body.velocity.y);

        animator.speed = vertGreater ? ySpeed / maxNormal : xSpeed / maxNormal;

        animator.SetBool(UP, vertGreater && positive);
        animator.SetBool(DOWN, vertGreater && !positive);
        animator.SetBool(LEFT, !vertGreater && !positive);
        animator.SetBool(RIGHT, !vertGreater && positive);
    }

    public string GetDirection()
    {
        foreach (var direction in DirectionTriggers)
        {
            if (animator.GetBool(direction))
            {
                return direction;
            }
        }

        return string.Empty;
    }
}
