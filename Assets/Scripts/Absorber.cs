using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Absorber : MonoBehaviour
{
    public Rigidbody2D RBody { get; private set; }
    public Collider2D Collider { get; private set; }

    private void Start()
    {
        RBody = GetComponent<Rigidbody2D>();
        Collider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ballistic")
        {
            Destroy(collision.gameObject);
        }
    }
}
