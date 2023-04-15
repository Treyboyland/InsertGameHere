using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteController : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    [SerializeField]
    Rigidbody2D body;

    [SerializeField]
    float maxNormal;

    const string UP = "Up";
    const string DOWN = "Down";
    const string LEFT = "Left";
    const string RIGHT = "Right";

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
}
