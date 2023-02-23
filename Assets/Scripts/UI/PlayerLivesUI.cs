using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLivesUI : MonoBehaviour
{
    [SerializeField]
    ObjectPool lifePool;

    [SerializeField]
    int livesPerHeart;

    List<PlayerLifeUI> lives = new List<PlayerLifeUI>();

    public void UpdateLives(Player player)
    {
        //TODO: Loss of max life?
        int lifeCount = player.MaxLives / livesPerHeart;
        lifeCount += player.MaxLives % livesPerHeart != 0 ? 1 : 0;
        if (lives.Count < lifeCount)
        {
            while (lives.Count < lifeCount)
            {
                var life = lifePool.GetObject().GetComponent<PlayerLifeUI>();
                life.gameObject.SetActive(true);
                life.transform.SetParent(transform);
                lives.Add(life);
            }
        }

        for (int i = 0; i < lives.Count; i++)
        {
            var heart = lives[i];
            heart.HeartIndex = i;
            heart.SetHeartSprite(player.CurrentLives, livesPerHeart);
        }
    }
}
