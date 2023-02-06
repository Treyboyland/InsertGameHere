using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
    int maxLives;

    [SerializeField]
    SpriteRenderer spriteRenderer;

    [SerializeField]
    Collider2D playerCollider;

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

    [Header("Events")]
    [SerializeField]
    GameEvent onUpdateLives;

    [SerializeField]
    GameEvent onPlayerDamaged;

    public Vector2Int CurrentRoomLocation { get; set; } = new Vector2Int();
    public int CurrentLives { get => currentLives; }
    public int MaxLives { get => maxLives; set => maxLives = value; }

    int currentLives;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        currentLives = maxLives;
        onUpdateLives.Invoke();
    }

    public void TakeDamage()
    {
        currentLives--;
        onUpdateLives.Invoke();
        onPlayerDamaged?.Invoke();
        if (currentLives <= 0)
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
        currentLives = maxLives;
        onUpdateLives.Invoke();
        spriteRenderer.enabled = true;
        playerCollider.enabled = true;
    }

    public void FireWeapon(DirectionSO direction)
    {
        if (weapon && CanPerformAction)
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

    public bool IsImmobilized { get; set; } = false;

    public bool CanPerformAction
    {
        get
        {
            return !IsImmobilized && currentLives > 0;
        }
    }
}
