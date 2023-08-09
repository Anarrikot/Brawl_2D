using UnityEngine;

public class Bullet_shelly_super : Bullet_shelly
{
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            collision.GetComponent<Box>().TakeDamage(hero.damageSuper);
            hero.CollectSuper(1);
        }
        if (collision.CompareTag("Enemy"))
        {
        }
        if (collision.CompareTag("WallNotDestroy"))
        {
            Destroy(gameObject);
        }
    }
}
