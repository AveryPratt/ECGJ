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

    private void Start()
    {
        Running = Time.timeScale > 0;
    }

    private void Update()
    {
        CountStallTime();
        CountCooldown();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TryStopTime();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            TryResumeTime();
        }
    }

    private void CountStallTime()
    {
        if (StallTime > 0)
        {
            StallTime -= Time.unscaledDeltaTime;
            if (StallTime < 0)
            {
                TryResumeTime();
                StallTime = 0;
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
            StallTime = StallTimeDuration;
        }
    }

    private void TryResumeTime()
    {
        if (!Running)
        {
            Running = true;
            Time.timeScale = 1;
            Cooldown = CooldownDuration;
        }
    }
}
