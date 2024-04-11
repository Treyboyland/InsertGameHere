using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TitleTooltips : MonoBehaviour
{
    [SerializeField]
    TMP_Text textBox;

    [SerializeField]
    float secondsPerTooltip;

    [TextArea]
    [SerializeField]
    List<string> tooltips;

    float elapsed = 0f;

    int currentIndex;
    // Start is called before the first frame update
    void Start()
    {
        SetText();
    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed > secondsPerTooltip)
        {
            elapsed = 0;
            currentIndex = (currentIndex + 1) % tooltips.Count;
            SetText();
        }
    }

    void SetText()
    {
        textBox.text = tooltips[currentIndex];
    }
}
