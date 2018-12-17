using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Dragable : MonoBehaviour
{
    public SpriteRenderer Renderer { get; private set; }
    public CircleCollider2D DragCollider { get; private set; }
    public Vector2 Original { get; private set; }
    public bool Dragged { get; private set; }
    public bool Released { get; set; }

    public float MaxDragDistance = 3;

    private DragController DragController;
    private TimeController TimeController;

    private void Start()
    {
        Renderer = GetComponent<SpriteRenderer>();
        DragCollider = GetComponentInChildren<CircleCollider2D>();
        DragController = FindObjectOfType<DragController>();
        TimeController = FindObjectOfType<TimeController>();
        Dragged = false;
        Released = false;
    }

    private void Update()
    {
        float stopped = TimeController.Running ? 0 : 1;
        Renderer.material.SetFloat("Boolean_96C78809", stopped);

        float ready = Released ? 0 : 1;
        Renderer.material.SetFloat("Boolean_7A34FC9", ready);

        Renderer.material.SetVector("Vector4_F8C84DBD", new Vector4(Time.unscaledTime, 0, 0, 0));

        if (DragCollider)
        {
            DragCollider.gameObject.SetActive(!TimeController.Running);
        }

        if (Dragged && TimeController.Running)
        {
            Dragged = false;
        }

        if (Released && TimeController.Running)
        {
            Released = false;
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
