using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotatingMove : EnemyMove
{
    [SerializeField]
    Rigidbody2D body;

    [SerializeField]
    float raycastDistance;

    [SerializeField]
    bool randomizeDirection;

    [SerializeField]
    DirectionSO initialDirection;

    [SerializeField]
    bool rotateClockwise;

    [SerializeField]
    List<DirectionSO> allDirections;


    bool movementSet = false;

    float elapsed = 0;

    DirectionSO currentDirection;

    GameObject currentCollision;

    private void OnEnable()
    {
        movementSet = false;
        currentCollision = null;
        if (randomizeDirection)
        {
            currentDirection = allDirections.RandomItem();
        }
        else
        {
            currentDirection = initialDirection;
        }
    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
        if (ShouldPerformAction())
        {
            if (!movementSet || body.velocity.normalized != currentDirection.NormalizedVector)
            {
                movementSet = true;
                SetSpeed();
            }
            CheckCollisions();
        }
        else
        {
            movementSet = false;
            body.velocity = Vector2.zero;
        }
    }

    void CheckCollisions()
    {
        //Not sure if this should collide with everything
        var hit = Physics2D.Raycast(transform.position, currentDirection.NormalizedVector, raycastDistance, LayerMask.GetMask("Wall", "Door", "EnemyBlocker"));
        if (hit && hit.collider.gameObject != currentCollision && elapsed > enemy.Stats.SecondsBetweenMove)
        {
            currentCollision = hit.collider.gameObject;
            elapsed = 0;
            RotateDirection();
        }
        else if (!hit)
        {
            currentCollision = null;
        }
    }

    void SetSpeed()
    {
        body.velocity = currentDirection.NormalizedVector * enemy.Stats.Speed;
    }

    void RotateDirection()
    {
        currentDirection = rotateClockwise ? currentDirection.Right : currentDirection.Left;
        SetSpeed();
    }

    // private void OnCollisionEnter2D(Collision2D other)
    // {
    //     var player = other.gameObject.GetComponent<Player>();

    //     if (!player && elapsed > enemy.Stats.SecondsBetweenMove)
    //     {
    //         currentCollision = other.gameObject;
    //         elapsed = 0;
    //         RotateDirection();
    //     }

    // }

    // private void OnCollisionStay2D(Collision2D other)
    // {
    //     var player = other.gameObject.GetComponent<Player>();

    //     if (!player && elapsed > enemy.Stats.SecondsBetweenMove && currentCollision != other.gameObject)
    //     {
    //         currentCollision = other.gameObject;
    //         elapsed = 0;
    //         RotateDirection();
    //     }
    // }
}
