using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponRanged : PlayerWeapon
{
    [SerializeField]
    ObjectPool pool;

    [SerializeField]
    OwnerTypeSO playerOwner;

    [SerializeField]
    GameEventVector weaponFiredEvent;

    public override void HandleFireAction(DirectionSO direction)
    {
        var obj = pool.GetObject();
        if (!obj)
        {
            return;
        }

        Projectile projectile = obj.GetComponent<Projectile>();
        if (projectile)
        {
            projectile.Owner = playerOwner;
            projectile.transform.position = transform.position;
            projectile.transform.SetParent(null);
            projectile.gameObject.SetActive(true);
            projectile.SetDirection(direction);
        }

        if (weaponFiredEvent)
        {
            weaponFiredEvent.Value = transform.position;
            weaponFiredEvent.Invoke();
        }
    }
}
