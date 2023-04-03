using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableObjectOnProjectileHit : MonoBehaviour, IDamageable
{
    [SerializeField]
    GameEvent onTriggerReached;

    [SerializeField]
    GameObject objectToDisable;

    [SerializeField]
    int numberOfHitsRequired;

    int currentNumHits = 0;

    private void OnEnable()
    {
        currentNumHits = 0;
    }


    void IDamageable.Damage(int amount)
    {
        currentNumHits++;
        if (currentNumHits >= numberOfHitsRequired)
        {
            onTriggerReached.Invoke();
            objectToDisable.SetActive(false);
        }
    }
}
