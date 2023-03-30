using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CountdownTimer : MonoBehaviour
{
    [SerializeField] bool _runOnEnable = false;
    [SerializeField] float _time;
    [SerializeField] UnityEvent _onComplete;

    // Start is called before the first frame update
    void OnEnable()
    {
        if (_runOnEnable)
        {
            StartCountdown();
        }
    }

    void OnDisable() => StopAllCoroutines();

    void StartCountdown()
    {
        StopAllCoroutines();
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown() 
    { 
        yield return new WaitForSeconds(_time);
        _onComplete.Invoke();
    }
}
