using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour, IPushable, IMoveable
{
    [SerializeField]
    Player player;

    [SerializeField]
    float speed;

    [SerializeField]
    Rigidbody2D body;

    [SerializeField]
    float thresholdMagnitude;

    [SerializeField]
    float secondsToWait;

    float elapsed = 0;

    Vector2 currentMovementVector;

    public void HandleMove(InputAction.CallbackContext context)
    {
        //Debug.LogWarning("Handling");
        currentMovementVector = context.ReadValue<Vector2>();
        elapsed = 0;
    }

    Queue<Action> _physicsActions = new Queue<Action>();

    void FixedUpdate()
    {
        while (_physicsActions.Count > 0)
        {
            _physicsActions.Dequeue().Invoke();
        }

        if (player.CanPerformAction)
        {
            elapsed += Time.fixedDeltaTime;
            if (elapsed >= secondsToWait && body.velocity.sqrMagnitude < thresholdMagnitude)
            {
                body.velocity = new Vector2();
            }
            Move();
        }
    }

    void Move()
    {
        Vector2 movement = currentMovementVector;
        if (movement != new Vector2())
        {
            elapsed = 0;
        }
        movement *= speed * Time.fixedDeltaTime;
        body.AddForce(movement, ForceMode2D.Impulse);
    }

    #region IPushable
    public void Push(Vector2 force)
    {
        _physicsActions.Enqueue(() => {
            body.AddForce(force, ForceMode2D.Impulse);
        });
    }
    #endregion

    #region IMoveable

    public void MoveTo(Vector2 target)
    {
        _physicsActions.Enqueue(() => {
            body.MovePosition(target);
        });
    }
    
    #endregion
}
