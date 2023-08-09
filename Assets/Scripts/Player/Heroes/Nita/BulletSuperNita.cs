using UnityEngine;
using UnityEngine.SocialPlatforms;

public class BulletSuperNita : MonoBehaviour
{
    public Vector3 finishPosition;
    public Bear_NIta projectilePrefab;
    public GameObject parant;
    public int lvlHero;
    public Nita nita;
    public float angle = 0;


    public void Update()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.position = Vector3.MoveTowards(transform.position, finishPosition, 0.05f);
        if (transform.position == finishPosition)
        {
            if (nita.myBear != null)
                Destroy(nita.myBear.gameObject);
            Bear_NIta bear = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            bear.transform.position = finishPosition;
            bear.transform.parent = parant.transform;
            bear.lvl_hero = lvlHero;
            bear.myNita = nita;
            Destroy(gameObject);
        }
        angle += 0.2f;
    }
}
