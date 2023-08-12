using System.Collections;
using UnityEditor.U2D.Path;
using UnityEngine;
using UnityEngine.AI;

public class bot : MonoBehaviour
{
    MyHero hero;
    private NavMeshAgent agent;
    private Transform target;
    public float playerX;
    public float playerY;
    public Transform playerSprite;
    bool isAttack;
    private Coroutine myCoroutine;

    void Start()
    {
        int number = Random.Range(0, PlayerInfo.Instance.myBrawlers.listBrawlers.Count);
        hero = Instantiate(Resources.Load<MyHero>("Prefabs/Hero/" + PlayerInfo.Instance.myBrawlers.listBrawlers[number].name + "/" + PlayerInfo.Instance.myBrawlers.listBrawlers[number].name));
        hero.transform.parent = transform;
        hero.transform.localPosition = Vector3.zero;
        hero.lvl = 1;
        if (gameObject.tag == "Teammate")
        {
            hero.HPslide.GetComponent<SpriteRenderer>().color = Color.blue;
            hero.Cirle.GetComponent<SpriteRenderer>().color = Color.blue;
        }
        else if (gameObject.tag == "Enemy")
        {
            hero.HPslide.GetComponent<SpriteRenderer>().color = Color.red;
            hero.Cirle.GetComponent<SpriteRenderer>().color = Color.red;
        }


        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.speed = 2f;

        playerSprite = hero.GetComponent<Transform>();

        playerX = playerSprite.transform.localScale.x;
        playerY = playerSprite.transform.localScale.y;
        hero.AmmoBackground.SetActive(false);
    }


    void Update()
    {
        FindTarget();
        agent.SetDestination(target.position);
        if (target.position.x > transform.position.x)
            playerSprite.transform.localScale = new Vector3(playerX, playerY, transform.localScale.z);
        else
            playerSprite.transform.localScale = new Vector3(-playerX, playerY, transform.localScale.z);
    }

    private void FindTarget()
    {
        if (GameObject.FindGameObjectWithTag("Box") != null)
        {
            GameObject[] targets = GameObject.FindGameObjectsWithTag("Box");
            Transform closestEnemy = null;
            float closestDistance = float.MaxValue;
            foreach (GameObject tar in targets)
            {
                float distance = Vector3.Distance(transform.position, tar.transform.position);
                if (distance < closestDistance)
                {
                    closestEnemy = tar.transform;
                    closestDistance = distance;
                }
            }
            target = closestEnemy;
        }
        else
            target = GameObject.FindGameObjectWithTag("Player").transform;
    }



    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Box")
        {
            agent.speed = 0;
            isAttack = true;
            myCoroutine = StartCoroutine(Attack(collision));
        }

    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Box")
        {
            agent.speed = 2f;
            isAttack = false;
            StopCoroutine(myCoroutine);
        }
    }

    IEnumerator Attack(Collider2D collision)
    {
        while (isAttack)
        {
            Vector3 direction = collision.transform.position - transform.position;
            float angleAttack = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            if (hero.isSuperReady)
                hero.Super(angleAttack, false);
            hero.Attack(angleAttack, false);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
