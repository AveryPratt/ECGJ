using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GoalCounter : MonoBehaviour
{
    public int GoalCount { get; set; }
    private Level Level;

    private void Start()
    {
        GoalCount = GetComponentsInChildren<Goal>().Length;
        Level = FindObjectOfType<Level>();
    }

    public void ReachGoal()
    {
        GoalCount -= 1;

        if (GoalCount == 0)
        {
            Level.CompleteLevel();
        }
    }
}
