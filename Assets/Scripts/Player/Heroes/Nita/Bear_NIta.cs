using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Bear_NIta : MonoBehaviour
{
    public int lvl_hero;
    public int hp;
    public int damage;
    private float speed = 2.5f;
    private float timeDelayAttack = 0.8f;

    private Transform target;
    private NavMeshAgent agent;
    private bool isAttack;
    private Coroutine myCoroutine;

    public void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.speed = speed;
        damage = Convert.ToInt32(Math.Round(400 + 400 * 0.05 * (lvl_hero - 1)));

        target = GameObject.FindGameObjectWithTag("Box").transform;
    }

    public void Update()
    {
        FindTarget();
        agent.SetDestination(target.position);
    }

    private void FindTarget()
    {
        target = GameObject.FindGameObjectWithTag("Box").transform;
        if (target == null)
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
            yield return new WaitForSeconds(timeDelayAttack);
        }
    }
}
