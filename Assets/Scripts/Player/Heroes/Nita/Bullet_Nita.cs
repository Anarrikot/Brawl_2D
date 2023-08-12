using System.Collections.Generic;
using UnityEngine;

public class Bullet_Nita : MonoBehaviour
{
    private readonly float speed = 4f;
    private readonly float timeAlive = 0.65f;
    public Rigidbody2D rb;
    public Vector2 direction;
    public List<GameObject> listDamage;
    public MyHero hero;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, timeAlive);
        rb.velocity = direction * speed;
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Box") && !listDamage.Contains(collision.gameObject))
        {
            listDamage.Add(collision.gameObject);
            collision.GetComponent<Box>().TakeDamage(hero.damage);
            hero.CollectSuper(1);
        }
        if (collision.CompareTag("Enemy") && !listDamage.Contains(collision.gameObject))
        {
            if (!collision.gameObject == hero.gameObject)
            {
                listDamage.Add(collision.gameObject);
                collision.transform.GetComponentInChildren<MyHero>().TakeDamage(hero.damage);
                hero.CollectSuper(1);
            }
        }
    }
}
