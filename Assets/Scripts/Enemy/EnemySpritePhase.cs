using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpritePhase : MonoBehaviour
{
    [SerializeField]
    Enemy enemy;

    [SerializeField]
    SpriteRenderer enemySprite;

    [SerializeField]
    List<Sprite> phaseSprites;

    // Update is called once per frame
    void Update()
    {
        SetSprite();
    }

    void SetSprite()
    {
        int phase = enemy.CurrentPhase;
        if (phase >= phaseSprites.Count)
        {
            enemySprite.sprite = phaseSprites[phaseSprites.Count - 1];
        }
        else
        {
            enemySprite.sprite = phaseSprites[phase];
        }
    }
}
