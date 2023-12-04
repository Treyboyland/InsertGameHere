using System.Collections;
using System.Collections.Generic;
using rho;
using UnityEngine;

[CreateAssetMenu(fileName = "DropTableSO", menuName = "Item/Drop Table Smart", order = 2)]
public class DropTableSmartSO : DropTableAbstract
{
    [Header("Probabilities")]
    [SerializeField]
    AnimationCurve healthDropProbability;

    [SerializeField]
    AnimationCurve keyDropProbability;

    [SerializeField]
    AnimationCurve timeDropProbability;


    [SerializeField]
    float chestProbability;

    [Header("Drops")]
    [SerializeField]
    List<ItemWeight> healthDrops;

    [SerializeField]
    List<ItemWeight> keyDrops;

    [SerializeField]
    List<ItemWeight> timeDrops;

    [SerializeField]
    List<ItemWeight> scoreDrops;

    [Header("Other stuff")]
    [SerializeField]
    ItemSO keyItem;

    [SerializeField]
    GameObject chestItem;

    [SerializeField]
    RuntimeInt lives;

    [SerializeField]
    RuntimeFloat remainingTime;

    [SerializeField]
    RuntimeInventory inventory;


    public override GameObject GetGameObject()
    {
        float healthProc, timeProc, keyProc;

        healthProc = healthDropProbability.Evaluate(lives.Value);
        timeProc = timeDropProbability.Evaluate(remainingTime.Value);
        keyProc = keyDropProbability.Evaluate(inventory.GetItemCount(keyItem));

        float max = Mathf.Max(healthProc, timeProc, keyProc);

        float probability = Random.Range(0.0f, 1.0f);

        Debug.LogWarning($"Health {healthProc} Time {timeProc} Key {keyProc} Max {max} Prob {probability}");

        bool useHealth, useKey, useTime;

        useHealth = probability <= healthProc && healthProc == max;
        useTime = probability <= timeProc && timeProc == max;
        useKey = probability <= keyProc && keyProc == max;

        List<ItemWeight> toUse;

        if (useTime)
        {
            toUse = timeDrops;
        }
        else if (useHealth)
        {
            toUse = healthDrops;
        }
        else if (useKey)
        {
            toUse = keyDrops;
        }
        else
        {
            if (Random.Range(0.0f, 1.0f) <= chestProbability)
            {
                return chestItem;
            }
            toUse = scoreDrops;
        }

        return toUse.GetItem().Item;
    }
}
