using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class AnyKeyCheck : MonoBehaviour
{
    [SerializeField]
    GameEvent onPressEvent;

    // Start is called before the first frame update
    void Start()
    {
        InputSystem.onAnyButtonPress.CallOnce(x => onPressEvent.Invoke());
    }
}
