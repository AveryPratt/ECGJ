using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public Targetable Target;
    public Shootable ShotPrefab;
    public float ShotInterval;
    public float ShotAngle = 90;

    private float IntervalTimer = 0;

    private void Update()
    {
        IntervalTimer += Time.deltaTime;

        if (IntervalTimer >= ShotInterval)
        {
            Shoot();
            IntervalTimer -= ShotInterval;
        }
    }

    private void Shoot()
    {
        float angle = ShotAngle;

        if (Target)
        {
            Vector2 path = Target.transform.position - transform.position;
            angle = Vector2.SignedAngle(transform.up, path);
        }

        ShotPrefab.transform.rotation = Quaternion.AngleAxis(angle, transform.forward);

        Shootable shot = Instantiate(ShotPrefab);
        shot.transform.position = transform.position;
    }
}
