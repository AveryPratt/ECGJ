using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotation : MonoBehaviour
{
    private void Start()
    {
        int val = Mathf.FloorToInt(Random.value * 4);
        transform.Rotate(transform.forward, val * 90);
    }
}
