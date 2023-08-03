using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Spawn_attack_Nita : MonoBehaviour
{
    public Bullet_Nita projectilePrefab;

    public void Attack(float angle)
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        Bullet_Nita projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Vector2 direction = Quaternion.Euler(0, 0, 0) * transform.right;
        projectile.direction = direction;
        projectile.transform.rotation = transform.rotation;
    }
}
