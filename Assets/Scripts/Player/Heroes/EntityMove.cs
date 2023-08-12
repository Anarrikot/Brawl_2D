
using System.Xml;
using System;
using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class EntityMove : MonoBehaviour
{

    public Transform target;
    public NavMeshAgent agent;
    public float playerX;
    public float playerY;
    public Transform playerSprite;

    public void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        playerX = playerSprite.localScale.x;
        playerY = playerSprite.localScale.y;
    }

    private void Update()
    {
        FindTarget();
        agent.SetDestination(target.position);
        if (target.position.x > transform.position.x)
            playerSprite.localScale = new Vector3(playerX, playerY, transform.localScale.z);
        else
            playerSprite.localScale = new Vector3(-playerX, playerY, transform.localScale.z);
    }

    private void FindTarget()
    {
        if (CompareTag("Player") || CompareTag("Teammate"))
        {
            if (GameObject.FindGameObjectWithTag("Box") != null || GameObject.FindGameObjectWithTag("Enemy") != null)
            {
                GameObject[] targetBox = GameObject.FindGameObjectsWithTag("Box");
                GameObject[] targetenemies = GameObject.FindGameObjectsWithTag("Enemy");

                GameObject[] targets = new GameObject[targetBox.Length + targetenemies.Length];
                targetBox.CopyTo(targets, 0);
                targetenemies.CopyTo(targets, targetBox.Length);

                Transform closestEnemy = null;
                float closestDistance = float.MaxValue;
                foreach (GameObject tar in targets)
                {
                    float distance = Vector3.Distance(transform.position, tar.transform.position);
                    if (distance < closestDistance)
                    {
                        closestEnemy = tar.transform;
                        closestDistance = distance;
                    }
                }
                target = closestEnemy;
            }
            else
                target = GetComponentInChildren<Entity>().myHero.transform;
        }
        else if (CompareTag("Enemy"))
        {
            if (GameObject.FindGameObjectWithTag("Box") != null || GameObject.FindGameObjectWithTag("Teammate") != null || GameObject.FindGameObjectWithTag("Player") != null)
            {
                GameObject[] targetBox = GameObject.FindGameObjectsWithTag("Box");
                GameObject[] targetTrametes = GameObject.FindGameObjectsWithTag("Teammate");
                GameObject[] targetPlayer = GameObject.FindGameObjectsWithTag("Player");

                GameObject[] targets = new GameObject[targetBox.Length + targetTrametes.Length + targetPlayer.Length];
                targetBox.CopyTo(targets, 0);
                targetTrametes.CopyTo(targets, targetBox.Length);
                targetPlayer.CopyTo(targets, targetTrametes.Length);

                Transform closestEnemy = null;
                float closestDistance = float.MaxValue;
                foreach (GameObject tar in targets)
                {
                    if (tar != null)
                    {
                        float distance = Vector3.Distance(transform.position, tar.transform.position);
                        if (distance < closestDistance)
                        {
                            closestEnemy = tar.transform;
                            closestDistance = distance;
                        }
                    }
                }
                target = closestEnemy;
            }
            else
                target = GetComponentInChildren<Entity>().myHero.transform;
        }
    }
}
