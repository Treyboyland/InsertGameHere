using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChewingTargetDisabler : MonoBehaviour
{
    [SerializeField] CabinetMimicStateInfo _stateInfo;

    void OnEnable()
    {
        _stateInfo.ChewingTarget?.SetActive(false);
    }

    void OnDisable()
    {
        _stateInfo.ChewingTarget?.SetActive(true);
    }
}
