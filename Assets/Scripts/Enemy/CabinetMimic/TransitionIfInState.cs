using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CabinetMimicStateMachine))]
public class TransitionIfInState : MonoBehaviour
{
    [SerializeField] CabinetMimicState _currentStateCondition;
    [SerializeField] CabinetMimicState _transitionState;

    public void Transition()
    {
        var sm = GetComponent<CabinetMimicStateMachine>();
        if (sm.State == _currentStateCondition)
        {
            sm.State = _transitionState;
        }
    }
}
