using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract partial class Projectile : MonoBehaviour
{
    [Header("Projectile settings")]
    public float speed = 500;
    public Rigidbody rigid;

    public GameObject onHitEffect;

    [HideInInspector] public Vector3 direction;
    protected bool isHit = false;

    private void Start()
    {
        if (direction == Vector3.zero)
            direction = transform.forward;

        rigid.AddForce(direction.normalized * speed);
    }
}
