using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TutorialController : MonoBehaviour
{
    public Text Text { get; private set; }
    public int TaskNumber { get; private set; }
    public CanvasGroup CanvasGroup;

    private float alpha;

    private void Start()
    {
        Text = GetComponent<Text>();

        alpha = 0;
    }

    private void Update()
    {
        if (alpha < 1)
        {
            alpha += Time.unscaledDeltaTime;
            if (alpha > 1)
            {
                alpha = 1;
            }
        }

        if (TaskNumber == 1 && Time.timeScale == 1)
        {
            CanvasGroup.alpha = 0;
        }
        else
        {
            CanvasGroup.alpha = alpha;
        }
        Debug.Log(alpha);

        if (TaskNumber == 0)
        {
            Text.text = "Hold Space";
        }
        else if (TaskNumber == 1)
        {
            Text.text = "Click and Drag";
        }
        else
        {
            Text.text = "Hit the Box";
        }
    }

    public void CompleteTask1()
    {
        TaskNumber = 1;
        alpha = 0;
    }

    public void CompleteTask2()
    {
        TaskNumber = 2;
        alpha = 0;
    }
}
