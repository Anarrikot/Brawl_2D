using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_attack_shelly : MonoBehaviour
{
    public Transform projectilePrefab;
    private float projectileSpeed = 4f;
    private int numShots = 5;
    private float duration = 0.7f;
    public MyHero Shelly;
    private float angleBetweenShots = 5f;

    private List<Transform> projectiles = new List<Transform>();

    private static Spawn_attack_shelly _instance;
    public static Spawn_attack_shelly Instance
        => _instance ??= new Spawn_attack_shelly();

    public Spawn_attack_shelly()
    {
        _instance = this;
    }

    public void Attack(float angel)
    {
        StartCoroutine(ShootShotgun(angel));
    }

    private IEnumerator ShootShotgun(float angel)
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angel));

        float startingAngle = -(numShots - 1) * angleBetweenShots / 2f;

        Transform projectile1 = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        projectiles.Add(projectile1);
        Vector2 direction = Quaternion.Euler(0, 0, startingAngle + 0 * angleBetweenShots) * transform.right;
        projectile1.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;

        Transform projectile2 = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        projectiles.Add(projectile2);
        direction= Quaternion.Euler(0, 0, startingAngle + 1 * angleBetweenShots) * transform.right;
        projectile2.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;

        Transform projectile3 = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        projectiles.Add(projectile3);
        direction = Quaternion.Euler(0, 0, startingAngle + 2 * angleBetweenShots) * transform.right;
        projectile3.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;

        Transform projectile4 = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        projectiles.Add(projectile4);
        direction = Quaternion.Euler(0, 0, startingAngle + 3 * angleBetweenShots) * transform.right;
        projectile4.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;

        Transform projectile5 = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        projectiles.Add(projectile5);
        direction = Quaternion.Euler(0, 0, startingAngle + 4 * angleBetweenShots) * transform.right;
        projectile5.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;

        yield return new WaitForSeconds(duration);

        foreach (Transform projectile in projectiles)
        {
            Destroy(projectile.gameObject);
        }

        projectiles.Clear();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
