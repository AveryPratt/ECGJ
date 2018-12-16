using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragable : MonoBehaviour
{
    private DragController Controller;

    private void Start()
    {
        Controller = FindObjectOfType<DragController>();
    }

    private void OnMouseDown()
    {
        Controller.Target = this;
    }
}
