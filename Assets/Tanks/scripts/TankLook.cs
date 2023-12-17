using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankLook : MonoBehaviour
{
    private GameObject target;
    private Vector3 mousePos;
    private float angle;
    private Vector3 objPos;

    // Update is called once per frame
    void Update()
    {
        target = transform.parent.gameObject;
        mousePos = Input.mousePosition;

        objPos = Camera.main.WorldToScreenPoint(target.transform.position);

        mousePos.x -= objPos.x;
        mousePos.y -= objPos.y;

        angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
