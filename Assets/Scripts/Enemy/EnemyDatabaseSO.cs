using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyDatabase", menuName = "Enemy/Database")]
public class EnemyDatabaseSO : ScriptableObject
{
    [SerializeField]
    List<Enemy> enemies;

    public List<Enemy> Enemies { get => enemies; }
}
