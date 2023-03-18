using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLivesUI : MonoBehaviour
{
    [SerializeField]
    ObjectPool lifePool;

    [SerializeField]
    int livesPerHeart;

    [SerializeField]
    rho.RuntimeInt currentLives;

    [SerializeField]
    rho.ConfigInt maxLives;

    List<PlayerLifeUI> lives = new List<PlayerLifeUI>();

    public void UpdateLives()
    {
        //TODO: Loss of max life?
        int lifeCount = maxLives.Value / livesPerHeart;
        lifeCount += maxLives.Value % livesPerHeart != 0 ? 1 : 0;
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
            heart.SetHeartSprite(currentLives.Value, livesPerHeart);
        }
    }
}
