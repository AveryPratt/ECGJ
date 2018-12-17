using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class NonDragable : MonoBehaviour
{
    public SpriteRenderer Renderer { get; private set; }
    private TimeController TimeController;

    private void Start()
    {
        Renderer = GetComponent<SpriteRenderer>();
        TimeController = FindObjectOfType<TimeController>();
    }
    
    private void Update()
    {
        float stopped = TimeController.Running ? 0 : 1;
        Renderer.material.SetFloat("Boolean_96C78809", stopped);
    }
}
