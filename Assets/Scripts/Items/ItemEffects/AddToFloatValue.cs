using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AddToFloatValue", menuName = "Item/ItemEffects/Add to Float Value")]
public class AddToFloatValue : ItemEffectSO
{
    [SerializeField] rho.RuntimeFloat _value;
    [SerializeField] float _amount;

    public override void Apply()
    {
        _value.Value += _amount;
    }
}
