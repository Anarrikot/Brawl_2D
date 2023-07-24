using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public DynamicJoystick dynamicJoystick;
    public Rigidbody2D rb;
    public GameObject attackSprite;
    public Transform playerSprite;
    public StaticJostic staticJoystick;

    private void Start()
    {
        attackSprite.SetActive(false);
    }

    private void Update()
    {
        if (staticJoystick.isActive)
        {
            if (staticJoystick.Horizontal != 0 || staticJoystick.Vertical != 0)
            {
                attackSprite.SetActive(true);
                float angle = Mathf.Atan2(staticJoystick.Vertical, staticJoystick.Horizontal) * Mathf.Rad2Deg;
                attackSprite.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            }
        }
        else
            attackSprite.SetActive(false);
    }

        public void FixedUpdate()
    {
        if (dynamicJoystick.isActive)
        {
            if (dynamicJoystick.Horizontal > 0)
            {
                playerSprite.localScale = new Vector3(1, 1, 1);
                attackSprite.transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                playerSprite.localScale = new Vector3(-1, 1, 1);
                attackSprite.transform.localScale = new Vector3(-1, 1, 1);
            }
            rb.velocity = new Vector2(dynamicJoystick.Horizontal * speed, dynamicJoystick.Vertical * speed);
        }
        else
            rb.velocity = Vector3.zero;
    }
}
