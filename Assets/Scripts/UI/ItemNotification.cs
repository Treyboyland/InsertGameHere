using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemNotification : MonoBehaviour
{
    [SerializeField]
    TMP_Text titleText;

    [SerializeField]
    TMP_Text descriptionText;

    [SerializeField]
    Animator animator;

    [SerializeField]
    float secondsToWait;

    [SerializeField]
    string waitingState;

    [SerializeField]
    string endTrigger;

    public void StartNotification(ItemSO itemData)
    {
        animator.gameObject.SetActive(false);
        titleText.text = itemData.ItemName;
        descriptionText.text = itemData.Description;
        StopAllCoroutines();
        StartCoroutine(Animate());
    }

    IEnumerator Animate()
    {
        animator.gameObject.SetActive(true);
        yield return StartCoroutine(animator.WaitForState(waitingState));
        yield return new WaitForSeconds(secondsToWait);
        animator.SetTrigger(endTrigger);
    }
}
