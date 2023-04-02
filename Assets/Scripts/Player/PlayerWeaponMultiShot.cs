using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerWeaponMultiShot : PlayerWeapon
{
    [Serializable]
    public struct BulletPosition
    {
        [Tooltip("Offset from player center of bullet")]
        public Vector2 Offset;
        [Tooltip("Angle from center this bullet will fire")]
        public float Rotation;
    }

    [SerializeField]
    ObjectPool pool;

    [SerializeField]
    GameEventVector weaponFiredEvent;

    [SerializeField]
    List<BulletPosition> positions;

    void CreateProjectile(DirectionSO direction, BulletPosition positionData)
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
            Quaternion rotation = Quaternion.AngleAxis(positionData.Rotation, Vector3.forward);

            Quaternion positionRotation = Quaternion.AngleAxis(direction.RotationFromNorth, Vector3.forward);
            Vector3 offset = positionRotation * (Vector3)positionData.Offset;
            projectile.transform.position = transform.position + offset;
            projectile.transform.SetParent(null);
            projectile.gameObject.SetActive(true);
            projectile.SetDirection((rotation * (Vector3)direction.NormalizedVector));
        }
    }

    public override void HandleFireAction(DirectionSO direction)
    {
        foreach (var positionData in positions)
        {
            CreateProjectile(direction, positionData);
        }

        if (weaponFiredEvent)
        {
            weaponFiredEvent.Value = transform.position;
            weaponFiredEvent.Invoke();
        }
    }
}
