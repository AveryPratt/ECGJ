using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GoalCounter : MonoBehaviour
{
    public int GoalCount { get; set; }

    public CanvasGroup VictoryCanvasGroup;

    private Level Level;
    private float VictoryTimer = 0;
    private bool Victorious = false;
    private AudioManager AudioManager;

    private void Start()
    {
        GoalCount = GetComponentsInChildren<Goal>().Length;
        Level = FindObjectOfType<Level>();
        AudioManager = FindObjectOfType<AudioManager>();
    }

    private void Update()
    {
        if (Victorious)
        {
            VictoryTimer += Time.unscaledDeltaTime;

            if (VictoryTimer > 3)
            {
                Continue();
            }

            VictoryCanvasGroup.alpha = VictoryTimer;
        }
    }

    public void ReachGoal()
    {
        GoalCount -= 1;

        if (GoalCount == 0)
        {
            Victorious = true;
            AudioManager.Victory.Play();
        }
    }

    private void Continue()
    {
        Level.CompleteLevel();
    }
}
