using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Reflector : MonoBehaviour
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
        GameObject other = collision.gameObject;
        if (other.tag == "Ballistic")
        {
            Reflect(other);
        }
    }

    private void Reflect(GameObject other)
    {
        Rigidbody2D rbody = other.GetComponent<Rigidbody2D>();
        Vector2 offset = other.transform.position - transform.position;

        Vector2 newVel;
        if (Mathf.Abs(offset.x) > Mathf.Abs(offset.y))
        {
            newVel = new Vector2(-rbody.velocity.x, rbody.velocity.y);
        }
        else
        {
            newVel = new Vector2(rbody.velocity.x, -rbody.velocity.y);
        }

        float angle = Vector2.SignedAngle(rbody.velocity, newVel);
        other.transform.Rotate(Vector3.forward, angle);
        rbody.velocity = newVel;
    }
}
