using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    [Range(0, 360)]
    public float viewAngle;
    [Range(1, 99)]
    public int numOfParticles = 1;

    //CastInView
    public void CastInView(Transform proj)
    {
        Vector3 viewAngleA = DirFromAngle(-viewAngle / 2);
        Vector3 viewAngleB = DirFromAngle(viewAngle / 2);

        int particles = numOfParticles + 1;

        // even or odd checkki
        float intervalA = (viewAngle) / particles;
        float intervalNow = 0f;

        for (int i = 1; i < particles; i++)
        {
            intervalNow += intervalA;

            var viewAngleRay = DirFromAngle(((viewAngle / 2) - intervalNow));

            SpawnProjectile(proj, viewAngleRay);
        }
    }

    void SpawnProjectile(Transform projectile, Vector3 direction)
    {
        GameObject GO = Instantiate(projectile.gameObject);
        Projectile skill = GO.GetComponent<Projectile>();
        GO.transform.position = transform.position;

        skill.direction = transform.forward + direction.normalized;
    }

    public Vector3 DirFromAngle(float angleInDeg)
    {
        return new Vector3(Mathf.Sin(angleInDeg * Mathf.Deg2Rad), 0f, Mathf.Cos(angleInDeg * Mathf.Deg2Rad));
    }

}
