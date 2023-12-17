using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Rigidbody2D bullet;
    public Transform firepos;
    public float fireSpeed = 250f;

    private GameObject player;
    private float angle;

    private void Awake()
    {
        StartCoroutine(shoot());
    }

    private void Start()
    {
        
    }

    void Update()
    {
        player = GameObject.Find("player_tank");
        lookAtPlayer();
    }

    void lookAtPlayer()
    {
        angle = Mathf.Atan2(player.transform.position.y - transform.position.y, player.transform.position.x - transform.position.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    IEnumerator shoot()
    {
        yield return new WaitForSeconds(2);
        var firedBullet = Instantiate(bullet, firepos.position, firepos.rotation);
        firedBullet.AddForce(firepos.right * fireSpeed);

        StartCoroutine(shoot());
    }
}
