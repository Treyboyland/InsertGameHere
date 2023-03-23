using UnityEngine;
using UnityEngine.Events;

public class OnGameObjectEnterTrigger : MonoBehaviour
{
    [SerializeField] RuntimeGameObject _target;
    [SerializeField] UnityEvent<Collider2D> _callback;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == _target.Value)        
        {
            _callback.Invoke(other);
        }
    }
}
