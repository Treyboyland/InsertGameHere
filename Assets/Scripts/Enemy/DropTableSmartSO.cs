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

        float choiceRand, randomChoiceMax;

        randomChoiceMax = healthProc + timeProc + keyProc;
        choiceRand = Random.Range(0.0f, randomChoiceMax);

        float cap = timeProc;


        bool useHealth, useKey, useTime, healthChosen = false, keyChosen = false, timeChosen = false;

        if(choiceRand <= cap)
        {
            timeChosen = true;
        }
        else 
        {
            cap+= healthProc;
            if(choiceRand <= cap)
            {
                healthChosen = true;
            }
            else
            {
                cap += keyProc;
                if(choiceRand <= cap)
                {
                    keyChosen = true;
                }
            }
        }

        useHealth = probability <= healthProc && healthChosen;
        useTime = probability <= timeProc && timeChosen;
        useKey = probability <= keyProc && keyChosen;

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
