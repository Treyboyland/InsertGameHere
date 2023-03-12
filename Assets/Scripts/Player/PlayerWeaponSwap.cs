using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponSwap : MonoBehaviour
{
    [SerializeField]
    Player player;

    [SerializeField]
    List<PlayerWeapon> weapons;

    int currentIndex = 0;

    public void NextWeapon()
    {
        currentIndex = (currentIndex + 1) % weapons.Count;
        UpdateWeapons();
    }

    public void PreviousWeapon()
    {
        currentIndex--;
        if (currentIndex < 0)
        {
            currentIndex = weapons.Count - 1;
        }
        UpdateWeapons();
    }

    void UpdateWeapons()
    {
        player.Weapon = weapons[currentIndex];
    }
}
