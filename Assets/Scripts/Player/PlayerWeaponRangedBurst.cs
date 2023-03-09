using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponRangedBurst : PlayerWeapon
{
    [SerializeField]
    ObjectPool pool;

    [SerializeField]
    OwnerTypeSO playerOwner;

    [SerializeField]
    GameEventVector weaponFiredEvent;

    [Tooltip("First shot will fire immediately. Last time will act as delay between bursts")]
    [SerializeField]
    List<float> shotTimes;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
