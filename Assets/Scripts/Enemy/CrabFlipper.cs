using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabFlipper : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    [SerializeField]
    EnemyWeaponFireDirection weapon;

    [SerializeField]
    CrabData upStuff;

    [SerializeField]
    CrabData downStuff;

    [Serializable]
    public struct CrabData
    {
        public List<Vector2> FireDirections;
        public RuntimeAnimatorController Animator;
    }

    private void OnEnable()
    {
        bool lookUp = UnityEngine.Random.Range(0.0f, 1.0f) < 0.5f;

        var dataToUse = lookUp ? upStuff : downStuff;

        animator.runtimeAnimatorController = dataToUse.Animator;
        weapon.Directions = dataToUse.FireDirections;
    }
}
