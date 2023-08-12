using UnityEngine;
using UnityEngine.SocialPlatforms;

public class BulletSuperNita : MonoBehaviour
{
    public Vector3 finishPosition;
    public GameObject projectilePrefab;
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
                Destroy(nita.myBear.transform.parent.gameObject);
            GameObject bearGO = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Bear_NIta bear = bearGO.GetComponentInChildren<Bear_NIta>();
            bear.transform.position = finishPosition;
            bearGO.transform.parent = parant.transform;
            bearGO.tag = nita.transform.parent.tag;
            bear.lvl_hero = lvlHero;
            bear.myHero = nita;
            Destroy(gameObject);
        }
        angle += 0.2f;
    }
}
