using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListenerDirectionSO : MonoBehaviour
{
    [SerializeField]
    GameEventDirectionSO gameEvent;

    public UnityEvent<DirectionSO> Response;

    private void OnEnable()
    {
        gameEvent.AddListener(this);
    }

    private void OnDisable()
    {
        gameEvent.RemoveListener(this);
    }
}
