using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AddToIntValue", menuName = "Item/ItemEffects/Add to Int Value")]
public class AddToIntValue : ItemEffectSO
{
    [SerializeField] rho.RuntimeInt _value;
    [SerializeField] int _amount;

    public override void Apply()
    {
        _value.Value += _amount;
    }
}
