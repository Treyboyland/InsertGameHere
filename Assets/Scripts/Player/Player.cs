using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
    int maxLives;

    [SerializeField]
    PlayerWeapon weapon;

    [Header("Directions")]
    [SerializeField]
    DirectionSO up;
    [SerializeField]
    DirectionSO down;
    [SerializeField]
    DirectionSO left;
    [SerializeField]
    DirectionSO right;

    public bool HasQuarter { get; set; } = false;

    public bool HasCartridge { get; set; } = false;

    public Vector2Int CurrentRoomLocation { get; set; } = new Vector2Int();

    int currentLives;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        currentLives = 0;
    }

    public void TakeDamage()
    {
        currentLives--;
        if (currentLives <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        gameObject.SetActive(false);
    }

    public void FireWeapon(DirectionSO direction)
    {
        if (weapon)
        {
            weapon.HandleFireAction(direction);
        }
    }

    public void HandleWeaponFireLeft(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            FireWeapon(left);
        }
    }

    public void HandleWeaponFireRight(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            FireWeapon(right);
        }
    }

    public void HandleWeaponFireUp(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            FireWeapon(up);
        }
    }

    public void HandleWeaponFireDown(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            FireWeapon(down);
        }
    }
}
