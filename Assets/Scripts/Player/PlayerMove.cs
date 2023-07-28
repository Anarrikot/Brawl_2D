using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public DynamicJoystick dynamicJoystick;
    public Rigidbody2D rb;
    public GameObject attackSprite;
    public GameObject superSprite;
    public Transform playerSprite;
    public StaticJostic staticJoystick;
    public StaticJosticSuper staticJosticSuper;
    public RectTransform staticJosticSuperObject;
    public MyHero MyHero;
    public Collider2D heroCollider;

    public float atSpX;
    public float atSpY;
    public float supSpX;
    public float supSpY;

    private Vector2 previousPosition;

    public void Start()
    {
        heroCollider = GetComponent<Collider2D>();
        attackSprite.SetActive(false);
        superSprite.SetActive(false);
        atSpX = attackSprite.transform.localScale.x;
        atSpY = attackSprite.transform.localScale.y;
        supSpX = superSprite.transform.localScale.x;
        supSpY = superSprite.transform.localScale.y;

        previousPosition = transform.position;
    }

    public void LateUpdate()
    {
        previousPosition = transform.position;
    }

    public void FixedUpdate()
    {
        if (dynamicJoystick.isActive)
        {
            if (dynamicJoystick.Horizontal > 0)
            {
                playerSprite.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                playerSprite.localScale = new Vector3(-1, 1, 1);
            }
            rb.velocity = new Vector2(dynamicJoystick.Horizontal * speed, dynamicJoystick.Vertical * speed);
        }
        else
            rb.velocity = Vector3.zero;


        if (staticJoystick.isActiveAttack)
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


        if (staticJosticSuper.isActiveSuper)
        {
            if (staticJosticSuper.Horizontal != 0 || staticJosticSuper.Vertical != 0)
            {
                superSprite.SetActive(true);
                MyHero.Cirle_supre.GetComponent<SpriteRenderer>().color = Color.yellow;
                float angle = Mathf.Atan2(staticJosticSuper.Vertical, staticJosticSuper.Horizontal) * Mathf.Rad2Deg;
                superSprite.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
                if (MyHero.isHiroSuperTrow)
                {
                    superSprite.GetComponent<FixedScale>().FixeScaleX = supSpX * staticJosticSuper.magnitudeSuper;
                } 
            }
        }
        else
        {
            superSprite.SetActive(false);
            MyHero.Cirle_supre.GetComponent<SpriteRenderer>().color = Color.blue;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Wall"))
        {
            transform.position = previousPosition;
        }
    }
}
