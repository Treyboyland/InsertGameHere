using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider2DMatchTiling : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer spriteRenderer;

    [SerializeField]
    BoxCollider2D spriteCollider;

    [SerializeField]
    int usedToTriggerOnValidate;

    private void OnValidate()
    {
        if (spriteCollider && spriteRenderer)
        {
            SetColliderToTile();
        }
    }

    public void SetColliderToTile()
    {
        var size = spriteRenderer.size;
        spriteCollider.size = size;
        spriteCollider.offset = new Vector2(0, -size.y / 2);
    }
}
