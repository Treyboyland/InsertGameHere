using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListenerVectorInt : MonoBehaviour
{
    [SerializeField]
    GameEventVectorInt gameEvent;

    public UnityEvent<Vector3Int> Response;

    private void OnEnable()
    {
        gameEvent.AddListener(this);
    }

    private void OnDisable()
    {
        gameEvent.RemoveListener(this);
    }
}
