using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Spawn_super_Nita : MonoBehaviour
{
    public BulletSuperNita projectilePrefab;

    public GameObject startPosition;
    public int lvlHero;
    public Nita nita; 

    public void Attack(float angle, bool isAvtoAttack)
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        BulletSuperNita grenade = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        if (isAvtoAttack)
            grenade.finishPosition = transform.position;
        else
            grenade.finishPosition = startPosition.transform.position;
        grenade.parant = transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject;
        grenade.lvlHero = lvlHero;
        grenade.nita = nita;
        grenade.transform.rotation = transform.rotation;
    }
}
