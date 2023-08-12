using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Bear_NIta : Entity
{ 
    private bool isAttack;
    private Coroutine myCoroutine;



    public override void Start()
    {
        speed = 1.5f;
        timeDelayAttack = 0.8f;        
        agent.speed = speed;
        damage = Convert.ToInt32(Math.Round(400 + 400 * 0.05 * (lvl_hero - 1)));
        hp = Convert.ToInt32(Math.Round(4000 + 4000 * 0.05 * (lvl_hero - 1)));
        maxhp = hp;
        myHero.GetComponent<Nita>().myBear = this;

        base.Start();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            agent.speed = 0;
            if (timeAttack > timeDelayAttack)
            {
                Attack(collision);
                timeAttack = 0;
            }
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Box"))
            agent.speed = speed;
        else if (collision.gameObject.CompareTag("Enemy") && (CompareTag("Player") || CompareTag("Teammate")))
            agent.speed = speed;
        else if ((collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Teammate")) && CompareTag("Enemy"))
            agent.speed = speed;
    }


    public void Attack(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Box"))
            collision.GetComponent<Box>().TakeDamage(damage);
        else if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Teammate") || collision.gameObject.CompareTag("Enemy"))
        {
            if (collision.GetComponentInChildren<MyHero>() != null)
                collision.GetComponentInChildren<MyHero>().TakeDamage(damage);
            else
                collision.GetComponent<Entity>().TakeDamage(damage);
        }
        myHero.CollectSuper(0.5f);
    }
}
