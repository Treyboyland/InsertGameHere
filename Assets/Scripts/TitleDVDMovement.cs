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
        List<float> possibleProgress = new List<float>() { 0.125f, 0.125f * 3, 0.125f * 5, 0.125f * 7 };
        int chosen = Random.Range(0, possibleProgress.Count);
        float progress = possibleProgress[chosen];
        Vector2 direction = new Vector2(Mathf.Cos(2 * Mathf.PI * progress), Mathf.Sin(2 * Mathf.PI * progress));
        body.velocity = direction * speed;
    }
}
