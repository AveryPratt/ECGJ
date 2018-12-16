using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragable : MonoBehaviour
{
    public Vector2 Original { get; private set; }
    public bool Dragged { get; private set; }

    public float MaxDragDistance = 3;

    private DragController DragController;
    private TimeController TimeController;

    private void Start()
    {
        DragController = FindObjectOfType<DragController>();
        TimeController = FindObjectOfType<TimeController>();
        Dragged = false;
    }

    private void Update()
    {
        if (Dragged && TimeController.Running)
        {
            Dragged = false;
        }
    }

    private void OnMouseDown()
    {
        if (!TimeController.Running && !Dragged)
        {
            Original = transform.position;
            Dragged = true;
            DragController.Target = this;
        }
    }
}
