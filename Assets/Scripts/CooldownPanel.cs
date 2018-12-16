using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class CooldownPanel : MonoBehaviour
{
    private TimeController TimeController;
    private Image Image;

    private void Start()
    {
        TimeController = FindObjectOfType<TimeController>();
        Image = GetComponent<Image>();
    }

    private void Update()
    {
        float alpha = TimeController.Cooldown / TimeController.CooldownDuration;
        Image.color = new Color(Image.color.r, Image.color.g, Image.color.b, alpha);
    }
}
