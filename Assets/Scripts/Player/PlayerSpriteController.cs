using System.Collections;
using System.Collections.Generic;
using AK.Wwise;
using UnityEngine;

public class PlayerSpriteController : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    [SerializeField]
    Rigidbody2D body;

    [SerializeField]
    float maxNormal;

    [SerializeField]
    AK.Wwise.Switch footstepMaterial;

    [SerializeField]
    AK.Wwise.Event footstepEvent;

    public const string UP = "Up";
    public const string DOWN = "Down";
    public const string LEFT = "Left";
    public const string RIGHT = "Right";

    public Animator Animator { get => animator; }
    public Switch FootstepMaterial
    {
        get => footstepMaterial;
        set
        {
            footstepMaterial = value;
            footstepMaterial.SetValue(gameObject);
        }
    }

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
            //footstepEvent.Stop(gameObject);
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

    public void FireFootstepEvent()
    {
        footstepEvent.Post(gameObject);
    }
}
