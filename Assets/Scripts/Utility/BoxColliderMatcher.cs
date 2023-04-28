using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class BoxColliderMatcher : MonoBehaviour
{
    [SerializeField]
    BoxCollider2D boxCollider2D;

    [SerializeField]
    SpriteRenderer sprite;

    // Update is called once per frame
    void Update()
    {
        if (Application.isEditor && !Application.isPlaying && boxCollider2D != null && sprite != null)
        {
            if (sprite.drawMode == SpriteDrawMode.Sliced || sprite.drawMode == SpriteDrawMode.Tiled)
            {
                boxCollider2D.size = sprite.localBounds.size;
                boxCollider2D.offset = sprite.localBounds.center;
            }
        }
    }
}
