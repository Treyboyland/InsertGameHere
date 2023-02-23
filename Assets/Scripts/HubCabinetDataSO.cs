using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HubCabinetDataSO-", menuName = "Hub World/Cabinet")]
public class HubCabinetDataSO : ScriptableObject
{
    [SerializeField]
    ItemSO cabinetData;

    [SerializeField]
    Sprite activeSprite;

    [Header("Inactive")]

    [SerializeField]
    ItemSO inactiveCabinetData;

    [SerializeField]
    Sprite inactiveSprite;

    public ItemSO CabinetData { get => cabinetData; }
    public Sprite ActiveSprite { get => activeSprite; }
    public ItemSO InactiveCabinetData { get => inactiveCabinetData; }
    public Sprite InactiveSprite { get => inactiveSprite; }
}
