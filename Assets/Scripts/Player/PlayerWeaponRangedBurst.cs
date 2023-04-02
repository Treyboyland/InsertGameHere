using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponRangedBurst : PlayerWeapon
{
    [SerializeField]
    ObjectPool pool;

    [SerializeField]
    GameEventVector weaponFiredEvent;

    [Tooltip("First shot will fire immediately. Last time will act as delay between bursts")]
    [SerializeField]
    List<float> shotTimes;

    bool isFiring = false;

    public override void HandleFireAction(DirectionSO direction)
    {
        if (!isFiring)
        {
            StartCoroutine(FireBurst(direction));
        }
    }

    void CreateProjectile(DirectionSO direction)
    {
        var obj = pool.GetObject();
        if (!obj)
        {
            return;
        }

        Projectile projectile = obj.GetComponent<Projectile>();
        if (projectile)
        {
            projectile.OwnerSet = _playerSet;
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

    IEnumerator FireBurst(DirectionSO direction)
    {
        isFiring = true;

        foreach (var time in shotTimes)
        {
            CreateProjectile(direction);
            yield return new WaitForSeconds(time);
        }

        isFiring = false;
    }
}
