using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChewingTargetDisabler : MonoBehaviour
{
    [SerializeField] CabinetMimicStateInfo _stateInfo;
    [SerializeField] Transform _pushSource;
    [SerializeField] Transform _targetSpitFromLocation;
    [SerializeField] float _spitForce = 10f;

    void OnEnable()
    {
        _stateInfo.ChewingTarget?.SetActive(false);
    }

    void OnDisable()
    {
        if (_stateInfo.ChewingTarget != null)
        {
            _stateInfo.ChewingTarget.SetActive(true);
            _stateInfo.ChewingTarget.GetComponent<IMoveable>()?.MoveTo((Vector2) _targetSpitFromLocation.position);
            _stateInfo.ChewingTarget.GetComponent<IPushable>()?.Push(GetSpitVector());
        }
    }

    Vector2 GetSpitVector()
    {
        var direction = _targetSpitFromLocation.position.x < _pushSource.position.x ? Vector2.left : Vector2.right;
        return direction * _spitForce;
    }
}
