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

    Queue<KeyValuePair<ItemSO, int>> _messages = new Queue<KeyValuePair<ItemSO, int>>();

    IEnumerator Start()
    {
        while (true)
        {
            if (_messages.Count > 0)
            {
                var (itemData, amount) = _messages.Dequeue();

                // TODO Change message based off amount
                titleText.text = itemData.ItemName + " x" + amount;
                descriptionText.text = itemData.Description;
                yield return StartCoroutine(Animate());
            }
            else
            {
                yield return null;
            }
        }
    }

    IEnumerator Animate()
    {
        animator.gameObject.SetActive(true);
        yield return StartCoroutine(animator.WaitForState(waitingState));
        yield return new WaitForSeconds(secondsToWait);
        animator.SetTrigger(endTrigger);
        animator.gameObject.SetActive(false);
    }

    public void StartNotification(ItemSO itemData, int amount) => 
        _messages.Enqueue(new KeyValuePair<ItemSO, int>(itemData, amount));
}
