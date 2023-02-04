using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListenerVector : MonoBehaviour
{
    [SerializeField]
    GameEventVector gameEvent;

    public UnityEvent<Vector3> Response;

    private void OnEnable()
    {
        gameEvent.AddListener(this);
    }

    private void OnDisable()
    {
        gameEvent.RemoveListener(this);
    }
}
