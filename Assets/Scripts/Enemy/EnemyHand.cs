using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHand : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    public void GrabPlayer()
    {
        animator.SetTrigger("Grab");
    }
}
