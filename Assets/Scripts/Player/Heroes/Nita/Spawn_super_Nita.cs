using UnityEngine;

public class Spawn_super_Nita : MonoBehaviour
{
    public BulletSuperNita projectilePrefab;

    public GameObject startPosition;

    public void Attack(float angel)
    {
        Shoot(angel);
    }

    private void Shoot(float angel)
    {

        // ������� ��������� �������
        BulletSuperNita grenade = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        grenade.finishPosition = startPosition.transform.position;
        grenade.parant = transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject;
    }
}
