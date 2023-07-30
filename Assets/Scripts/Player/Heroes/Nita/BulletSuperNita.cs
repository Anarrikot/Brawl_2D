using UnityEngine;

public class BulletSuperNita : MonoBehaviour
{
    public Vector3 finishPosition;
    public Bear_NIta projectilePrefab;
    public GameObject parant;
    public int lvlHero;


    public void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, finishPosition, 0.01f);
        if (transform.position == finishPosition)
        {
            Bear_NIta grenade = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            grenade.transform.position = finishPosition;
            grenade.transform.parent = parant.transform;
            grenade.lvl_hero = lvlHero;
            Destroy(gameObject);
        }
    }
}
