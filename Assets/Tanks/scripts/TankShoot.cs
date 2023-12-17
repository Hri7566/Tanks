using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShoot : MonoBehaviour
{
    public Transform firepos;
    public Rigidbody2D bullet;
    public float fireSpeed = 250f;

    private float cooldown = 0f;
    private float cooldownTime = 1.5f;

    void Update()
    {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if (cooldown <= 0)
            {
                cooldown = cooldownTime;
                var firedBullet = Instantiate(bullet, firepos.position, firepos.rotation);
                firedBullet.AddForce(firepos.right * fireSpeed);
            }
        }
    }
}
