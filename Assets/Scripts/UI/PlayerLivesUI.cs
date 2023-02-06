using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLivesUI : MonoBehaviour
{
    [SerializeField]
    ObjectPool lifePool;

    List<PlayerLifeUI> lives = new List<PlayerLifeUI>();

    public void UpdateLives(Player player)
    {
        //TODO: Loss of max life?
        if (lives.Count < player.MaxLives)
        {
            while (lives.Count < player.MaxLives)
            {
                var life = lifePool.GetObject().GetComponent<PlayerLifeUI>();
                life.gameObject.SetActive(true);
                life.transform.SetParent(transform);
                lives.Add(life);
            }
        }

        for (int i = 0; i < player.MaxLives; i++)
        {
            lives[i].Active = i < player.CurrentLives;
        }
    }
}
