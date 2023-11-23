using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyFireOnPhase : MonoBehaviour
{
    [SerializeField]
    protected Enemy enemy;

    [SerializeField]
    protected EnemyWeaponFire weapon;

    [SerializeField]
    protected bool fireOnFirstPhase;

    protected HashSet<int> phases = new HashSet<int>();

    public UnityEvent<int> OnPhaseFire = new UnityEvent<int>();

    protected void Update()
    {
        bool canFire = enemy.CurrentPhase != 0 || (enemy.CurrentPhase == 0 && fireOnFirstPhase);
        if (!phases.Contains(enemy.CurrentPhase) && canFire)
        {
            OnPhaseFire.Invoke(enemy.CurrentPhase);
            phases.Add(enemy.CurrentPhase);
            Fire();
        }
    }

    protected void OnEnable()
    {
        phases.Clear();
    }

    public virtual void Fire()
    {
        weapon.Fire();
    }
}
