using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    public GameObject tank;
    public GameObject direction;
    public GameObject bodySprite;
    private float angle;
    private Vector3 objPos;

    public float speed = 2f;

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        direction.transform.SetPositionAndRotation(transform.position + new Vector3(x * 3000, y * 3000, 0), Quaternion.Euler(0, 0, 0));

        objPos = direction.transform.position;

        angle = Mathf.Atan2(objPos.y, objPos.x) * Mathf.Rad2Deg;


        Collider2D wallTouch = Physics2D.OverlapCircle(tank.transform.position, 5f, 8); // finish this


        transform.position = transform.position + new Vector3(x * speed * Time.deltaTime, y * speed * Time.deltaTime, 0);
        bodySprite.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    private void OnDestroy()
    {
        Debug.Log("Game over");
    }
}
