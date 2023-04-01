using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPushable
{
    // Start is called before the first frame update
    void Push(Vector2 force);
}
