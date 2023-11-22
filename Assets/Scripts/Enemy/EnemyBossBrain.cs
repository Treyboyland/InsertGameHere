using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBossBrain : MonoBehaviour
{
    [SerializeField]
    Enemy enemy;

    [SerializeField]
    EnemyFireOnPhase phaseFire;

    [SerializeField]
    float secondsVulnerable;

    [SerializeField]
    BossWeaponFireTowardsPlayer retaliationFire;

    [SerializeField]
    BossWeaponFireTowardsPlayer continuousFire;

    [SerializeField] BossWeaponFireTowardsPlayer vulnerableFire;

    [SerializeField]
    int numShotsOfRetaliation;

    [SerializeField]
    List<BossSwitch> bossSwitches;

    // Start is called before the first frame update
    void Start()
    {
        enemy.IsInvincible = true;

        foreach (var bossSwitch in bossSwitches)
        {
            bossSwitch.OnSwitchTurnedOn.AddListener(Retaliate);
        }

        continuousFire.StartContinuousFire();
        phaseFire.OnPhaseFire.AddListener((unused) => StopAndGoBackToNormal());
    }

    void Retaliate()
    {
        retaliationFire.BurstFire(numShotsOfRetaliation);

        if (AllSwitchesOn())
        {
            StartCoroutine(PlayerAttackChance());
        }
    }

    bool AllSwitchesOn()
    {
        foreach (var bossSwitch in bossSwitches)
        {
            if (!bossSwitch.IsOn)
            {
                return false;
            }
        }

        return true;
    }

    void TurnSwitchesOff()
    {
        foreach (var bossSwitch in bossSwitches)
        {
            bossSwitch.TurnOff();
        }
    }

    void StopAndGoBackToNormal()
    {
        StopAllCoroutines();
        BackToNormal();
    }

    void BackToNormal()
    {
        enemy.IsInvincible = true;
        TurnSwitchesOff();
        continuousFire.StartContinuousFire();
        vulnerableFire.StopContinuousFire();
    }

    IEnumerator PlayerAttackChance()
    {
        continuousFire.StopContinuousFire();
        vulnerableFire.StartContinuousFire();
        enemy.IsInvincible = false;
        yield return new WaitForSeconds(secondsVulnerable);
        BackToNormal();
    }
}
