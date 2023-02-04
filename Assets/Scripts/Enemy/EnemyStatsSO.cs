using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatsSO : MonoBehaviour
{
    [SerializeField]
    int health;

    [SerializeField]
    float speed;


    public int Health { get => health; }
    public float Speed { get => speed; }
}
