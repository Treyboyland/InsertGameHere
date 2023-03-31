using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour, IPushable
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


    // Start is called before the first frame update
    void Start()
    {

    }

    public void HandleMove(InputAction.CallbackContext context)
    {
        //Debug.LogWarning("Handling");
        currentMovementVector = context.ReadValue<Vector2>();
        elapsed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.CanPerformAction)
        {
            elapsed += Time.deltaTime;
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
        movement *= speed * Time.deltaTime;
        body.AddForce(movement, ForceMode2D.Impulse);
    }

    IEnumerator PushAtFixedUpdate(Vector2 position, float force)
    {
        yield return new WaitForFixedUpdate();
        var difference = body.position - position;
        body.AddForce(difference * force, ForceMode2D.Impulse);
    }

    public void PushAwayFrom(Vector2 position, float force)
    {
        StartCoroutine(PushAtFixedUpdate(position, force));
    }
}
