using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_shelly_super : Bullet_shelly
{
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            collision.GetComponent<Box>().TakeDamage(MyHero.Instance.damage);
            MyHero.Instance.CollectSuper(1);
        }
        if (collision.CompareTag("Enemy"))
        {
        }
    }
}
