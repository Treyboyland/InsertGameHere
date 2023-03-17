using UnityEngine;
using UnityEngine.Events;

public class ParamterizedGameEventListener<T> : MonoBehaviour
{
    [SerializeField]
    ParamterizedGameEvent<T> gameEvent;

    public UnityEvent<T> Response;

    private void OnEnable()
    {
        gameEvent.AddListener(this);
    }

    private void OnDisable()
    {
        gameEvent.RemoveListener(this);
    }
}
