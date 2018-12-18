using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reflector : Absorber
{
    protected override void Absorb(Collider2D collision)
    {
        GameObject other = collision.gameObject;
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

        AudioManager.Reflect.Play();
    }
}
