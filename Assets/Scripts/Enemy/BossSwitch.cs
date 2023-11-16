using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

public class BossSwitch : MonoBehaviour
{
    [SerializeField]
    Collider2D trigger;

    [SerializeField]
    SpriteRenderer switchSprite;

    [SerializeField]
    Sprite onSprite;

    [SerializeField]
    Sprite offSprite;

    bool isOn = false;

    public bool IsOn => isOn;

    public UnityEvent OnSwitchTurnedOn;

    public void TurnOn()
    {
        trigger.enabled = false;
        switchSprite.sprite = onSprite;
        isOn = true;
        OnSwitchTurnedOn.Invoke();
    }

    public void TurnOff()
    {
        trigger.enabled = true;
        switchSprite.sprite = offSprite;
        isOn = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.gameObject.GetComponent<Player>();

        if (player && !isOn)
        {
            TurnOn();
        }
    }
}
