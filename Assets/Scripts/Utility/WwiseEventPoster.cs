using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WwiseEventPoster : MonoBehaviour
{
    [SerializeField]
    AK.Wwise.Event eventToPost;

    public void PostEvent()
    {
        eventToPost.Post(gameObject);
    }
}
