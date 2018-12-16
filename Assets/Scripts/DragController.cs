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
                Vector2 position;
                bool limited = LimitPosition(hit.point, out position);
                Target.transform.position = position;

                if (limited)
                {
                    Target = null;
                }
            }
            else
            {
                Debug.Log("Mouse is off HitScreen");
            }
        }
    }

    private bool LimitPosition(Vector2 mousePos, out Vector2 newPos)
    {
        float sqrMagnitude = Vector2.SqrMagnitude(mousePos - Target.Original);
        float sqrDragDist = Mathf.Pow(Target.MaxDragDistance, 2);

        if (sqrMagnitude > sqrDragDist)
        {
            newPos = Target.transform.position;
            return true;
        }
        else
        {
            newPos = mousePos;
            return false;
        }
    }
}
