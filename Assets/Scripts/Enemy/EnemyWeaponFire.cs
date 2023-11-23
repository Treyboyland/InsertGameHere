using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponFire : EnemyMove
{
    [SerializeField]
    protected ObjectPool bulletPool;

    [SerializeField]
    protected rho.RuntimeGameObjectSet _ownerSet;

    protected void SpawnProjectle(Vector2 direction)
    {
        var obj = bulletPool.GetObject();
        if (!obj)
        {
            return;
        }

        Projectile projectile = obj.GetComponent<Projectile>();
        if (!projectile)
        {
            return;

        }

        projectile.OwnerSet = _ownerSet;
        projectile.transform.position = transform.position;
        projectile.gameObject.SetActive(true);
        projectile.transform.SetParent(null);
        projectile.SetDirection(direction);
    }

    protected void SpawnProjectle(DirectionSO direction)
    {
        var obj = bulletPool.GetObject();
        if (!obj)
        {
            return;
        }

        Projectile projectile = obj.GetComponent<Projectile>();
        if (!projectile)
        {
            return;

        }

        projectile.OwnerSet = _ownerSet;
        projectile.transform.position = transform.position;
        projectile.gameObject.SetActive(true);
        projectile.transform.SetParent(null);
        projectile.SetDirection(direction);
    }

    public virtual void Fire()
    {
        //intentionally blank
    }
}
