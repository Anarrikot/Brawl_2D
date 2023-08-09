using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Tilemaps;

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

    public float atSpX;
    public float atSpY;
    public float supSpX;
    public float supSpY;
    public float playerX;
    public float playerY;

    public void Start()
    {
        Brawler brawler = CSVcontroller.Instance.ReadCSVActiveBrawler();
        MyHero = Instantiate(Resources.Load<MyHero>("Prefabs/Hero/" + brawler.name + "/" + brawler.name));
        MyHero.transform.parent = transform;
        MyHero.transform.localPosition = Vector3.zero;
        MyHero.playerMove = this;
        MyHero.lvl = brawler.power;
        playerSprite = MyHero.GetComponent<Transform>();
        attackSprite = MyHero.attackSprite;
        superSprite = MyHero.superSprite;
        attackSprite.SetActive(false);
        superSprite.SetActive(false);
        atSpX = attackSprite.transform.localScale.x;
        atSpY = attackSprite.transform.localScale.y;
        supSpX = superSprite.transform.localScale.x;
        supSpY = superSprite.transform.localScale.y;
        playerX = playerSprite.transform.localScale.x;
        playerY = playerSprite.transform.localScale.y;

        var agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }

    public void FixedUpdate()
    {
        if (dynamicJoystick.isActive)
        {
            if (dynamicJoystick.Horizontal > 0)
            {
                playerSprite.localScale = new Vector3(playerX, playerY, 1);
            }
            else
            {
                playerSprite.localScale = new Vector3(-playerX, playerY, 1);
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
}
