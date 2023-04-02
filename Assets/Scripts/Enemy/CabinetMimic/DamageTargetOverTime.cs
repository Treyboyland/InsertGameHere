using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTargetOverTime : MonoBehaviour
{
    [SerializeField] CabinetMimicStateInfo _stateInfo;
    [SerializeField] float _damageInterval;
    [SerializeField] bool _damageAtStart;
    [SerializeField] bool _stopAfterDuration;
    [SerializeField, NaughtyAttributes.ShowIf("_stopAfterDuration")] float _totalDuration;
    [SerializeField] int _damageAmount = 1;

    void OnEnable() => StartCoroutine(DamgeOverTime());

    void OnDisable() => StopAllCoroutines();

    IEnumerator DamgeOverTime()
    {
        if (_damageAtStart)
        {
            DamageTarget();
        }
        
        var elaspedTime = 0f;

        while (!_stopAfterDuration || elaspedTime < _totalDuration)
        {
            yield return new WaitForSeconds(_damageInterval);
            DamageTarget();
            elaspedTime += _damageInterval;
        }
    }

    void DamageTarget()
    {
        var damageable = _stateInfo.ChewingTarget.GetComponent<IDamageable>();
        damageable?.Damage(_damageAmount);
    }
}
