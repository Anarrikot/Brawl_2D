using System.IO;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Tilemaps;

public class TileDestroyer : MonoBehaviour
{
    private Tilemap destructibleTilemap;
    private NavMeshSurface2d navMeshSurface;

    private void Start()
    {
        destructibleTilemap = GetComponent<Tilemap>();
        navMeshSurface = transform.parent.GetComponent<NavMeshSurface2d>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Vector3 hitPosition = collision.transform.position;
            destructibleTilemap.SetTile(destructibleTilemap.WorldToCell(hitPosition), null);
            navMeshSurface.BuildNavMesh();
        }
    }
}
