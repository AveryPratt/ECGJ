using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
[RequireComponent(typeof(CanvasGroup))]
public class TimeIndicator : MonoBehaviour
{
    private TimeController TimeController;
    private Slider Slider;
    private CanvasGroup CanvasGroup;

    private void Start()
    {
        TimeController = FindObjectOfType<TimeController>();
        Slider = GetComponent<Slider>();
        CanvasGroup = GetComponent<CanvasGroup>();
    }

    private void Update()
    {
        Slider.value = TimeController.StallTime / TimeController.StallTimeDuration;
        CanvasGroup.alpha = Slider.value == 1 ? 0 : Slider.value;
    }
}
