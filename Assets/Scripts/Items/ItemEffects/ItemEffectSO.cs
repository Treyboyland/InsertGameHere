using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemEffectSO : ScriptableObject, IItemEffect
{
    public abstract void Apply();
}
