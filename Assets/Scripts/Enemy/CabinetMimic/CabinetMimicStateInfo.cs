using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CabinetMimicStateInfo : MonoBehaviour
{
    public GameObject ChewingTarget { get; set; }
    public void SetChewingTarget(RuntimeGameObject rtgo) => ChewingTarget = rtgo.Value;

    bool _lookingLeft = false;
    public bool LookingLeft 
    {
        get => _lookingLeft;
        set
        {
            if (_lookingLeft == value)
            {
                return;
            }
            
            _lookingLeft = value;
            _onLookingLeftChanged.Invoke(_lookingLeft);
        }
    }

    [SerializeField] UnityEvent<bool> _onLookingLeftChanged;
}
