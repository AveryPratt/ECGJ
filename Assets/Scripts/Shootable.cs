using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Shootable : MonoBehaviour
{
    public Rigidbody2D RBody { get; private set; }
    public Collider2D Collider { get; private set; }
    public float Speed;

    private void Start()
    {
        RBody = GetComponent<Rigidbody2D>();
        Collider = GetComponent<Collider2D>();
        RBody.velocity = transform.rotation * new Vector2(0, Speed);
    }
}
