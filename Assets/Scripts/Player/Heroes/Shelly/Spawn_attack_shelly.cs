using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_attack_shelly : MonoBehaviour
{
    public Bullet_shelly projectilePrefab;
    private int numShots = 5;
    private float angleBetweenShots = 5f;

    private List<Bullet_shelly> projectiles = new List<Bullet_shelly>();

    public void Attack(float angel)
    {
        ShootGun(angel);
    }

    private void ShootGun(float angel)
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angel));

        float startingAngle = -(numShots - 1) * angleBetweenShots / 2f;

        Bullet_shelly projectile1 = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Vector2 direction = Quaternion.Euler(0, 0, startingAngle + 0 * angleBetweenShots) * transform.right;
        projectile1.direction = direction;

        Bullet_shelly projectile2 = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        direction = Quaternion.Euler(0, 0, startingAngle + 1 * angleBetweenShots) * transform.right;
        projectile2.direction = direction;

        Bullet_shelly projectile3 = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        direction = Quaternion.Euler(0, 0, startingAngle + 2 * angleBetweenShots) * transform.right;
        projectile3.direction = direction;

        Bullet_shelly projectile4 = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        direction = Quaternion.Euler(0, 0, startingAngle + 3 * angleBetweenShots) * transform.right;
        projectile4.direction = direction;

        Bullet_shelly projectile5 = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        direction = Quaternion.Euler(0, 0, startingAngle + 4 * angleBetweenShots) * transform.right;
        projectile5.direction = direction;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
