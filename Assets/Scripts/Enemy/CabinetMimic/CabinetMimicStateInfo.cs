using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinetMimicStateInfo : MonoBehaviour
{
    public GameObject ChewingTarget { get; set; }
    public void SetChewingTarget(RuntimeGameObject rtgo) => ChewingTarget = rtgo.Value;
}
