using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpread : Projectile
{
    public Transform projectiles;
    public FieldOfView fieldOfView;

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Entity>() != null)
        {
            if (onHitEffect != null)
                Instantiate(onHitEffect, transform.position, transform.rotation);
            fieldOfView.CastInView(projectiles);
            Destroy(this.gameObject);
        }       
    }
}
