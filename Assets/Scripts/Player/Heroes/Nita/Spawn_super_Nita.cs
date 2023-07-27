using UnityEngine;

public class Spawn_super_Nita : MonoBehaviour
{
    public Bullet_Nita projectilePrefab;


    public void Attack(float angel)
    {
        Shoot(angel);
    }

    private void Shoot(float angel)
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angel));
        Bullet_Nita projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Vector2 direction = Quaternion.Euler(0, 0, 0) * transform.right;
        projectile.direction = direction;
        projectile.transform.rotation = transform.rotation;
    }
}
