using UnityEngine;
using UnityEngine.Tilemaps;

public class Bullet_shelly : MonoBehaviour
{
    private readonly float speed = 4f;
    private readonly float timeAlive = 0.65f;
    public Rigidbody2D rb;
    public Vector2 direction;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, timeAlive);
        rb.velocity = direction * speed;
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            collision.GetComponent<Box>().TakeDamage(MyHero.Instance.damage);
            MyHero.Instance.CollectSuper(1);
            Destroy(gameObject);
        }
        if (collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
        if (collision.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
