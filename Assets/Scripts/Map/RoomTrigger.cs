using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    [SerializeField]
    GameEvent triggerEvent;

    [SerializeField]
    SpriteRenderer sprite;

    [SerializeField]
    Collider2D trigger;

    public SpriteRenderer SpriteRenderer { get => sprite; }

    public Collider2D Trigger { get => trigger; }

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.LogWarning(gameObject.name + " Collision");
        if (other.gameObject.GetComponent<Player>() != null)
        {
            triggerEvent.Invoke();
        }
        else
        {
            //Debug.LogWarning("Did not collide with player");
        }
    }
}
