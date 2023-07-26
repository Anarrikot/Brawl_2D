using UnityEngine;
using UnityEngine.Tilemaps;

public class TileDestroyer : MonoBehaviour
{
    public Tilemap destructibleTilemap;
    private void Start()
    {
        destructibleTilemap = GetComponent<Tilemap>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Vector3 hitPosition = collision.transform.position;
            destructibleTilemap.SetTile(destructibleTilemap.WorldToCell(hitPosition), null);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Vector3 hitPosition = collision.transform.position;
            destructibleTilemap.SetTile(destructibleTilemap.WorldToCell(hitPosition), null);
        }
    }

   
}
