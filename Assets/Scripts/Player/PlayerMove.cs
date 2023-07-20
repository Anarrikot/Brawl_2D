using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public DynamicJoystick dynamicJoystick;
    public Rigidbody2D rb;

    public void FixedUpdate()
    {
        if (dynamicJoystick.isActive)
            rb.velocity = new Vector2(dynamicJoystick.Horizontal * speed, dynamicJoystick.Vertical * speed);
        else
            rb.velocity = Vector3.zero;
    }
}
