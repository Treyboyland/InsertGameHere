using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveContinuousBounce : EnemyMove
{
    [SerializeField]
    Rigidbody2D body;

    Vector2 storedVelocity;


    // Update is called once per frame
    void Update()
    {
        if (ShouldPerformAction())
        {
            body.velocity = storedVelocity;
        }
        else
        {
            body.velocity = Vector2.zero;
        }
    }

    private void OnEnable()
    {
        float randomDirection = Random.Range(0.0f, 360f);
        float x = Mathf.Cos(randomDirection) * enemy.Stats.Speed;
        float y = Mathf.Sin(randomDirection) * enemy.Stats.Speed;

        storedVelocity = new Vector2(x, y);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var collisionPoint = other.GetContact(0);
        var xDiff = Mathf.Abs(collisionPoint.point.x - transform.position.x);
        var yDiff = Mathf.Abs(collisionPoint.point.y - transform.position.y);

        //Normals for non-vertical or horizontal surfaces?

        if (xDiff > yDiff && ((collisionPoint.point.x > transform.position.x && storedVelocity.x < 0) ||
            (collisionPoint.point.x < transform.position.x && storedVelocity.x > 0)))
        {
            return;
        }

        if (xDiff <= yDiff && ((collisionPoint.point.y > transform.position.y && storedVelocity.y < 0) ||
            (collisionPoint.point.y < transform.position.y && storedVelocity.y > 0)))
        {
            return;
        }


        if (xDiff > yDiff)
        {
            storedVelocity.x *= -1;
        }
        else
        {
            storedVelocity.y *= -1;
        }

        body.velocity = ShouldPerformAction() ? storedVelocity : Vector2.zero;
    }
}
