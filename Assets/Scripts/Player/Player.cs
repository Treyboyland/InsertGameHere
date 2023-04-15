using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField]
    rho.ConfigInt maxLives;

    [SerializeField]
    rho.RuntimeInt currentLives;

    [SerializeField]
    SpriteRenderer spriteRenderer;

    [SerializeField]
    Collider2D playerCollider;

    [SerializeField]
    PlayerWeapon weapon;

    [SerializeField]
    PlayerWeaponSwap swap;

    [Header("Directions")]
    [SerializeField]
    DirectionSO up;
    [SerializeField]
    DirectionSO down;
    [SerializeField]
    DirectionSO left;
    [SerializeField]
    DirectionSO right;

    [Header("Events")]
    [SerializeField]
    GameEvent onUpdateLives;

    [SerializeField]
    GameEvent onPlayerDamaged;

    [SerializeField]
    GameEventDirectionSO onWeaponFired;

    public Vector2Int CurrentRoomLocation { get; set; } = new Vector2Int();

    public PlayerWeapon Weapon { get => weapon; set => weapon = value; }

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        currentLives.Value = maxLives.Value;
        onUpdateLives.Invoke();
    }

    public void Damage(int amount)
    {
        currentLives.Value--;
        onUpdateLives.Invoke();
        onPlayerDamaged?.Invoke();
        if (currentLives.Value <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        spriteRenderer.enabled = false;
        playerCollider.enabled = false;
    }

    public void Revive()
    {
        currentLives.Value = maxLives.Value;
        onUpdateLives.Invoke();
        spriteRenderer.enabled = true;
        playerCollider.enabled = true;
    }

    public void FireWeapon(DirectionSO direction)
    {
        if (weapon && CanPerformAction)
        {
            onWeaponFired.Value = direction;
            onWeaponFired.Invoke();
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

    public void HandleWeaponSwapNext(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            swap.NextWeapon();
        }
    }

    public void HandleWeaponSwapPrevious(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            swap.PreviousWeapon();
        }
    }

    public bool IsImmobilized { get; set; } = false;

    public bool CanPerformAction
    {
        get
        {
            return !IsImmobilized && currentLives.Value > 0;
        }
    }
}
