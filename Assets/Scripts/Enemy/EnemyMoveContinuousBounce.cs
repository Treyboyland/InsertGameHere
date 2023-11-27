using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveContinuousBounce : EnemyMove
{
    [SerializeField]
    Rigidbody2D body;

    [SerializeField]
    bool shouldCycle;

    Vector2 storedVelocity;

    float elapsed = 0;

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
        if (ShouldPerformAction())
        {
            body.velocity = CalculateVelocity();
        }
        else
        {
            body.velocity = Vector2.zero;
        }
    }

    Vector2 CalculateVelocity()
    {
        if (!shouldCycle)
        {
            return storedVelocity;
        }

        float timeCycled = 2 * Mathf.PI * (elapsed / enemy.Stats.SecondsBetweenMove);
        float multiple = Mathf.Abs(Mathf.Cos(timeCycled));

        return storedVelocity * multiple;
    }

    private void OnEnable()
    {
        elapsed = 0;
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

        body.velocity = ShouldPerformAction() ? CalculateVelocity() : Vector2.zero;
    }
}
