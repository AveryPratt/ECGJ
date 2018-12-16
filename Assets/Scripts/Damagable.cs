using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable : Absorber
{
    public SpriteRenderer Renderer { get; private set; }

    public int Health = 1;
    public Color StartColor;
    public Color EndColor;

    private float MaxHealth;

    private void Start()
    {
        Renderer = GetComponent<SpriteRenderer>();
        MaxHealth = Health;
    }

    protected override void Absorb(Collider2D collision)
    {
        Health -= 1;

        Destroy(collision.gameObject);

        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        float value = (MaxHealth - Health) / (MaxHealth - 1);
        Renderer.material.color = Color.Lerp(StartColor, EndColor, value);
    }
}
