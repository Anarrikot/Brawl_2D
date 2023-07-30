using UnityEngine;

public class Spawn_super_Nita : MonoBehaviour
{
    public BulletSuperNita projectilePrefab;

    public GameObject startPosition;
    public int lvlHero;

    public void Attack(float angel)
    {
        Shoot(angel);
    }

    private void Shoot(float angel)
    {

        // Создаем экземпляр гранаты
        BulletSuperNita grenade = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        grenade.finishPosition = startPosition.transform.position;
        grenade.parant = transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject;
        grenade.lvlHero = lvlHero;
    }
}
