using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListenerItemSO : MonoBehaviour
{
    [SerializeField]
    GameEventItemSO gameEvent;

    public UnityEvent<ItemSO> Response;

    private void OnEnable()
    {
        gameEvent.AddListener(this);
    }

    private void OnDisable()
    {
        gameEvent.RemoveListener(this);
    }
}
