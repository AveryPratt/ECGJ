using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public bool Running { get; private set; }
    public float StallTime { get; private set; }
    public float Cooldown { get; private set; }

    public float CooldownDuration = 1;
    public float StallTimeDuration = 3;

    private TutorialController Tutorial;

    private void Start()
    {
        Running = Time.timeScale > 0;
        StallTime = StallTimeDuration;
        Tutorial = FindObjectOfType<TutorialController>();
    }

    private void Update()
    {
        CountStallTime();
        CountCooldown();

        if (Input.GetKey(KeyCode.Space) && Cooldown <= 0)
        {
            TryStopTime();

            if (Tutorial && Tutorial.TaskNumber == 0)
            {
                Tutorial.CompleteTask1();
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            TryResumeTime();
        }
    }

    private void CountStallTime()
    {
        if (StallTime < StallTimeDuration)
        {
            StallTime += Time.unscaledDeltaTime;
            if (StallTime > StallTimeDuration)
            {
                TryResumeTime();
                StallTime = StallTimeDuration;
            }
        }
    }

    private void CountCooldown()
    {
        if (Cooldown > 0)
        {
            Cooldown -= Time.unscaledDeltaTime;
            if (Cooldown < 0)
            {
                Cooldown = 0;
            }
        }
    }

    private void TryStopTime()
    {
        if (Running && Cooldown <= 0)
        {
            Running = false;
            Time.timeScale = 0;
            StallTime = 0;
        }
    }

    private void TryResumeTime()
    {
        if (!Running)
        {
            Running = true;
            Time.timeScale = 1;
            Cooldown = CooldownDuration;
            StallTime = StallTimeDuration;
        }
    }
}
