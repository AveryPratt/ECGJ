using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragable : MonoBehaviour
{
    public CircleCollider2D DragCollider { get; private set; }
    public Vector2 Original { get; private set; }
    public bool Dragged { get; private set; }

    public float MaxDragDistance = 3;

    private DragController DragController;
    private TimeController TimeController;

    private void Start()
    {
        DragCollider = GetComponentInChildren<CircleCollider2D>();
        DragController = FindObjectOfType<DragController>();
        TimeController = FindObjectOfType<TimeController>();
        Dragged = false;
    }

    private void Update()
    {
        DragCollider.gameObject.SetActive(!TimeController.Running);

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
