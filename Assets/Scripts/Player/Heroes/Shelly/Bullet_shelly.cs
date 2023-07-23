using UnityEngine;

public class Bullet_shelly : MonoBehaviour
{
    private float speed = 4f;
    private float timeAlive = 0.65f;
    public Rigidbody2D rb;
    public Vector2 direction;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Destroy(gameObject, timeAlive);
        rb.velocity = direction * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
