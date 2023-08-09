using UnityEngine;

public class Spawn_super_shelly : MonoBehaviour
{
    public Bullet_shelly projectilePrefab;
    private int numShots = 9;
    private float angleBetweenShots = 5f;
    public MyHero hero;


    public void Attack(float angel)
    {
        Shoot(angel);
    }

    private void Shoot(float angel)
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angel));

        float startingAngle = -(numShots - 1) * angleBetweenShots / 2f;

        for (int i = 0; i < numShots; i++)
        {
            Bullet_shelly projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Vector2 direction = Quaternion.Euler(0, 0, startingAngle + i * angleBetweenShots) * transform.right;
            projectile.direction = direction;
            projectile.hero = hero;
        }

    }
}
