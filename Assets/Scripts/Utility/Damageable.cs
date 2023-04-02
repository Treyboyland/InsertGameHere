using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour, IDamageable
{
    [SerializeField] UnityEvent<int> _onDamge;

    public void Damage(int amount)
    {
        _onDamge.Invoke(amount);
    }
}
