using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteLookAtTarget : MonoBehaviour
{
    [SerializeField] SpriteRenderer _sprite;

    public void LookAtTarget(Vector2 target)
    {
        var currentPosition = (Vector2) transform.position;

        _sprite.flipX = currentPosition.x > target.x;
    }
}
