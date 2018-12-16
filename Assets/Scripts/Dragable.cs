using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragable : MonoBehaviour
{
    private DragController DragController;
    private TimeController TimeController;

    private void Start()
    {
        DragController = FindObjectOfType<DragController>();
        TimeController = FindObjectOfType<TimeController>();
    }

    private void OnMouseDown()
    {
        if (!TimeController.Running)
        {
            DragController.Target = this;
        }
    }
}
