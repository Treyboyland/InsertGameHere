using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleDVDMovement : MonoBehaviour
{
    [SerializeField]
    float speed;

    [SerializeField]
    Rigidbody body;

    // Start is called before the first frame update
    void Start()
    {
        float progress = Random.Range(0f, 1.0f);
        Vector2 direction = new Vector2(Mathf.Cos(2 * Mathf.PI * progress), Mathf.Sin(2 * Mathf.PI * progress));
        body.velocity = direction * speed;
    }
}
