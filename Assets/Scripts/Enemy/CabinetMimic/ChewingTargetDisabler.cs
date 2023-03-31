using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChewingTargetDisabler : MonoBehaviour
{
    [SerializeField] CabinetMimicStateInfo _stateInfo;
    [SerializeField] Transform _pushSource;

    void OnEnable()
    {
        _stateInfo.ChewingTarget?.SetActive(false);
    }

    void OnDisable()
    {
        if (_stateInfo.ChewingTarget != null)
        {
            _stateInfo.ChewingTarget.SetActive(true);
            _stateInfo.ChewingTarget.GetComponent<IPushable>()?.PushAwayFrom((Vector2) _pushSource.position, 10f);
        }
    }
}
