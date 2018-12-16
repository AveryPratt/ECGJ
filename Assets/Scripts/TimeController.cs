using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public float CooldownDuration = 1;
    private float cooldown;

    private void Update()
    {
        if (cooldown > 0)
        {
            cooldown -= Time.unscaledDeltaTime;
            if (cooldown < 0)
            {
                cooldown = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TryStopTime();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            TryResumeTime();
        }
    }

    private void TryStopTime()
    {
        if (Time.timeScale > 0 && cooldown <= 0)
        {
            Time.timeScale = 0;
        }
    }

    private void TryResumeTime()
    {
        if (Time.timeScale < 1)
        {
            Time.timeScale = 1;
            cooldown = CooldownDuration;
        }
    }
}
