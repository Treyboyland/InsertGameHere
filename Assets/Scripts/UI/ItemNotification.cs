using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

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

    [SerializeField, NaughtyAttributes.ValidateInput("IsAnimatorState", "Not a valid state name")]
    string waitingState;

    private bool IsAnimatorState(string stateName)
    {
#if UNITY_EDITOR
        var controller = animator.runtimeAnimatorController as UnityEditor.Animations.AnimatorController;
        return controller.layers.Any(l => l.stateMachine.states.Any(s => s.state.name == stateName));
#else
        return true;
#endif
    }

    [SerializeField, NaughtyAttributes.AnimatorParam("animator")]
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

    public void StartNotification(ItemSO itemData, int amount)
    {
        if (itemData.ShouldNotifyOnPickup && amount != 0)
        {
            _messages.Enqueue(new KeyValuePair<ItemSO, int>(itemData, amount));
        }
    }

}
