using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragController : MonoBehaviour
{
    public Dragable Target { get; set; }

    private TimeController TimeController;
    private TutorialController Tutorial;

    private void Start()
    {
        TimeController = FindObjectOfType<TimeController>();
        Tutorial = FindObjectOfType<TutorialController>();
    }

    private void Update()
    {
        if (Tutorial && Tutorial.TaskNumber == 1 && Target)
        {
            Tutorial.CompleteTask2();
        }

        if (Target && (Input.GetMouseButtonUp(0) || TimeController.Running))
        {
            Target.Released = true;
            Destroy(Target.RangeIndicator);
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
