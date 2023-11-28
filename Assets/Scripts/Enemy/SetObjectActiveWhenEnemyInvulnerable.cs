using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetObjectActiveWhenEnemyInvulnerable : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    [SerializeField] private GameObject obj;
    [SerializeField] private bool invert;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (invert)
        {
            obj.SetActive(!enemy.IsInvincible);
        }
        else
        {
            obj.SetActive(enemy.IsInvincible);
        }
    }
}
