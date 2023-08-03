using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Bear_NIta : MonoBehaviour
{
    public int lvl_hero;
    public int hp;
    public int maxhp;
    public int damage;
    private float speed = 1.5f;
    private float timeDelayAttack = 0.8f;

    public GameObject HPslide;
    public Text HPtext;

    private Transform target;
    private NavMeshAgent agent;
    private bool isAttack;
    private Coroutine myCoroutine;

    public float playerX;
    public float playerY;

    public Nita myNita;

    public void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.speed = speed;
        damage = Convert.ToInt32(Math.Round(400 + 400 * 0.05 * (lvl_hero - 1)));
        hp = Convert.ToInt32(Math.Round(4000 + 4000 * 0.05 * (lvl_hero - 1)));
        maxhp = hp;
        HPtext.text = hp.ToString();
        playerX = transform.localScale.x;
        playerY = transform.localScale.y;
        myNita.myBear = this;
    }

    public void Update()
    {
        FindTarget();
        agent.SetDestination(target.position);
        ShowHP();
        if (target.position.x > transform.position.x)
            transform.localScale = new Vector3(playerX, playerY, transform.localScale.z);
        else
            transform.localScale = new Vector3(-playerX, playerY, transform.localScale.z);
    }

    private void FindTarget()
    {
        if (GameObject.FindGameObjectWithTag("Box") != null)
            target = GameObject.FindGameObjectWithTag("Box").transform;
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
            agent.speed = speed;
            isAttack = false;
            StopCoroutine(myCoroutine);
        }
    }

    IEnumerator Attack(Collider2D collision)
    {
        while (isAttack)
        {
            yield return new WaitForSeconds(0.2f);
            collision.GetComponent<Box>().TakeDamage(damage);
            myNita.CollectSuper(0.5f);
            yield return new WaitForSeconds(timeDelayAttack);
        }
    }

    public void ShowHP()
    {
        HPtext.transform.position = Camera.main.WorldToScreenPoint(transform.position);
        HPtext.transform.position = new Vector3(HPtext.transform.position.x, (float)(HPtext.transform.position.y + Screen.height * 0.06), HPtext.transform.position.z);
    }
    public void TakeDamage(int damage)
    {
        hp -= damage;
        HPslide.transform.localScale = new Vector3((float)(hp) / maxhp, HPslide.transform.localScale.y, HPslide.transform.localScale.z);
        float newPosX = -(1f - HPslide.transform.localScale.x) / 2;
        HPslide.transform.localPosition = new Vector3(newPosX, HPslide.transform.localPosition.y, 0f);
    }

}
