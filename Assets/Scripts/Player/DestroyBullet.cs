using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
}
