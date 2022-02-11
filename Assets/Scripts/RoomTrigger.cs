using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    [SerializeField]
    GameEvent triggerEvent;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.LogWarning(gameObject.name + " Collision");
        if (other.gameObject.GetComponent<Player>() != null)
        {
            triggerEvent.Invoke();
        }
        else
        {
            Debug.LogWarning("Did not collide with player");
        }
    }
}
