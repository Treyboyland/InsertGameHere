using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats-", menuName = "Game/Enemy Stats")]
public class EnemyStatsSO : ScriptableObject
{
    [SerializeField]
    int health;

    [SerializeField]
    float speed;


    public int Health { get => health; }
    public float Speed { get => speed; }
}
