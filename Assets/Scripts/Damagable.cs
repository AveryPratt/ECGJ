using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Damagable : MonoBehaviour
{
    public Collider2D Collider { get; private set; }

    private void Start()
    {
        Collider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Damaging")
        {
            GetHit();
        }
    }

    private void GetHit()
    {

    }
}
