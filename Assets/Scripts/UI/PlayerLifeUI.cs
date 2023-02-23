using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLifeUI : MonoBehaviour
{
    [SerializeField]
    GameObject heart;

    [SerializeField]
    Image heartImage;

    [SerializeField]
    List<Sprite> lifeSprites;

    public bool Active
    {
        get => heart.activeInHierarchy;
        set => heart.SetActive(value);
    }

    public int HeartIndex { get; set; } = 0;

    public void SetHeartSprite(int playerLives, int livesPerHeart)
    {
        int spriteIndex = 0;

        int lifeStart = HeartIndex * livesPerHeart;

        if (playerLives >= lifeStart + livesPerHeart)
        {
            spriteIndex = lifeSprites.Count - 1;
        }
        else if (playerLives <= lifeStart)
        {
            spriteIndex = 0;
        }
        else
        {
            spriteIndex = playerLives - lifeStart;
        }

        heartImage.sprite = lifeSprites[spriteIndex];
    }
}
