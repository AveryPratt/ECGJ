using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Damagable))]
public class Goal : MonoBehaviour
{
    public GoalCounter Counter { get; private set; }

    private void Start()
    {
        Counter = FindObjectOfType<GoalCounter>();
    }

    private void OnDestroy()
    {
        if (Counter)
        {
            Counter.ReachGoal();
        }
    }
}
