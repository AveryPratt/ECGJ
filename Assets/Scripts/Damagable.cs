﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable : Absorber
{
    protected override void Absorb(Collider2D collision)
    {
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
