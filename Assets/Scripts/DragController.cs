using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragController : MonoBehaviour
{
    public Dragable Target { get; set; }
    private TimeController TimeController;

    private void Start()
    {
        TimeController = FindObjectOfType<TimeController>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0) || TimeController.Running)
        {
            Target.Released = true;
            Target = null;
        }
        else if (Input.GetMouseButton(0))
        {
            Drag();
        }
    }

    private void Drag()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Target != null)
        {
            if (Physics.Raycast(ray, out hit, 100, LayerMask.GetMask("HitScreen")))
            {
                Vector2 position = LimitPosition(hit.point);
                Target.transform.position = position;
            }
        }
    }

    private Vector2 LimitPosition(Vector2 mousePos)
    {
        Vector2 dist = Vector2.ClampMagnitude(mousePos - Target.Original, Target.MaxDragDistance);
        return Target.Original + dist;
    }
}
