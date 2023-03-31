using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleFlipper : MonoBehaviour
{
    public void FlipX(bool negative)
    {
        var newScale = transform.localScale;
        newScale.x = (negative ? -1 : 1) * Mathf.Abs(newScale.x);
        transform.localScale = newScale;
    }
}
