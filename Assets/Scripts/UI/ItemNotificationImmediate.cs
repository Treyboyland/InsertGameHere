using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemNotificationImmediate : MonoBehaviour
{
    [SerializeField]
    TMP_Text title;

    [SerializeField]
    TMP_Text description;

    [SerializeField]
    GameObject notificationObject;


    public void HideObject()
    {
        notificationObject.SetActive(false);
    }

    public void ShowObject()
    {
        notificationObject.SetActive(true);
    }

    public void ShowItem(ItemSO item)
    {
        title.text = item.ItemName;
        description.text = item.Description;
        ShowObject();
    }
}
