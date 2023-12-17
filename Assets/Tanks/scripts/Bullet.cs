using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float startTime;
    private float stopTime;
    private float collideTime;
    private float wallCollides = 0;
    private float maxWallCollides = 1;

    void Start()
    {
        startTime = Time.time;
        stopTime = startTime + 5f;
        collideTime = startTime + 0.05f;
    }

    void Update()
    {
        if (Time.time > stopTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tank" && Time.time > collideTime)
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "wall" && Time.time > collideTime)
        {
            Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();

            if (wallCollides >= maxWallCollides)
            {
                Destroy(gameObject);
            }

            if (transform.position.x < collision.transform.position.x - collision.gameObject.GetComponent<SpriteRenderer>().bounds.size.x/2 || transform.position.x > collision.transform.position.x + collision.gameObject.GetComponent<SpriteRenderer>().bounds.size.x / 2)
            {
                wallCollides++;
                rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
            }

            if (transform.position.y > collision.transform.position.y + collision.gameObject.GetComponent<SpriteRenderer>().bounds.size.y/2 || transform.position.y < collision.transform.position.y - collision.gameObject.GetComponent<SpriteRenderer>().bounds.size.y / 2)
            {
                wallCollides++;
                rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y);
            }
        }
    }

}
