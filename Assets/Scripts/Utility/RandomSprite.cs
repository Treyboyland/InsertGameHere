using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSprite : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer sprite;

    [SerializeField]
    List<Sprite> sprites;

    // Start is called before the first frame update
    void Start()
    {
        int index = Random.Range(0, sprites.Count);
        sprite.sprite = sprites[index];
    }
}
