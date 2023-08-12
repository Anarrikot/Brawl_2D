using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyHero : MonoBehaviour 
{
    public int damage;
    public int damageSuper;
    public int ammo;
    public int maxammo;
    public int hp;
    public int maxhp;
    public float speed;
    public float reloadtime;
    public float timedelayattack;
    public int lvl;
    public int bullets;
    public float bulletforsuper;
    public int countbulletforsuper;

    public bool isSuperReady = false;

    public GameObject HPslide;
    public Text HPtext;

    public GameObject Ammoslide;
    public List<GameObject> AmmoList;
    public GameObject AmmoBackground;

    public GameObject Cirle;
    public GameObject Cirle_supre;

    public GameObject attackSprite;
    public GameObject superSprite;

    private float timeReload;
    private float timeStartHeal;
    private float timeHeal;
    public float timeAttack;
    private readonly float percentOfHeal = 0.13f;

    public bool isHiroAttackTrow;
    public bool isHiroSuperTrow;

    public PlayerMove playerMove;

    GameObject[] enemies;
    GameObject[] boxObjects;
    GameObject[] combinedObjects;
    protected float angleAttack;
    protected float angleSuper;

    public virtual void Start()
    {
        SetAmmo();
        timeAttack = timedelayattack;
        HPslide.transform.parent = transform.parent;
        HPtext.text = hp.ToString();
    }

    public virtual void Update()
    {
        ShowHP();
        if (hp < maxhp) 
        {
            timeStartHeal += Time.deltaTime;
            if (timeStartHeal >= 3)
            {
                Heal();
            }
        }
        Reload();
        timeAttack += Time.deltaTime;
    }

    public virtual void Attack(float angle, bool isAvtoAttack)
    {
        timeHeal = 0;
        timeStartHeal = 0;
        angleAttack = angle;
        if (isAvtoAttack)
        {
            float closestDistance = Mathf.Infinity;
            GameObject closestEnemy = null;
            if (GameObject.FindGameObjectWithTag("Box") == null && GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                angleAttack = angle;
            }
            else
            {
                enemies = GameObject.FindGameObjectsWithTag("Enemy");
                boxObjects = GameObject.FindGameObjectsWithTag("Box");
                combinedObjects = new GameObject[enemies.Length + boxObjects.Length];
                enemies.CopyTo(combinedObjects, 0);
                boxObjects.CopyTo(combinedObjects, enemies.Length);


                foreach (GameObject obj in combinedObjects)
                {
                    float distanceToPlayer = Vector3.Distance(obj.transform.position, transform.position);

                    if (distanceToPlayer < closestDistance)
                    {
                        closestDistance = distanceToPlayer;
                        closestEnemy = obj;
                    }
                }
                Vector3 direction = closestEnemy.transform.position - transform.position;
                angleAttack = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            }
        }
    }

    public virtual void Super(float angle, bool isAvtoAttack)
    {
        timeHeal = 0;
        timeStartHeal = 0;
        angleSuper = angle;
        if (isAvtoAttack)
        {
            float closestDistance = Mathf.Infinity;
            GameObject closestEnemy = null;
            if (GameObject.FindGameObjectWithTag("Box") == null && GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                angleSuper = angle;
            }
            else
            {
                enemies = GameObject.FindGameObjectsWithTag("Enemy");
                boxObjects = GameObject.FindGameObjectsWithTag("Box");
                combinedObjects = new GameObject[enemies.Length + boxObjects.Length];
                enemies.CopyTo(combinedObjects, 0);
                boxObjects.CopyTo(combinedObjects, enemies.Length);


                foreach (GameObject obj in combinedObjects)
                {
                    float distanceToPlayer = Vector3.Distance(obj.transform.position, transform.position);

                    if (distanceToPlayer < closestDistance)
                    {
                        closestDistance = distanceToPlayer;
                        closestEnemy = obj;
                    }
                }
                Vector3 direction = closestEnemy.transform.position - transform.position;
                angleSuper = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            }
        }
        if (playerMove != null)
        {
            playerMove.staticJosticSuper.colorHandle = playerMove.staticJosticSuper.background.GetComponent<Image>().color;
            playerMove.staticJosticSuper.colorHandle.a = 0f;
            playerMove.staticJosticSuper.background.GetComponent<Image>().color = playerMove.staticJosticSuper.colorHandle;
            playerMove.staticJosticSuper.handle.GetComponent<Image>().color = Color.grey;
        }
    }

    public  void TakeDamage(int damage)
    {
        hp -= damage;
        HPslide.transform.localScale = new Vector3((float)(hp) / maxhp, HPslide.transform.localScale.y, HPslide.transform.localScale.z);
        float newPosX = -(1f - HPslide.transform.localScale.x) / 2;
        HPslide.transform.localPosition = new Vector3(newPosX, HPslide.transform.localPosition.y, 0f);
        timeHeal = 0;
        timeStartHeal = 0;
    }

    public void Heal()
    {
        timeHeal += Time.deltaTime;
        if (timeHeal >= 1)
        {
            if (hp <= maxhp - Mathf.Round(maxhp * percentOfHeal))
            {
                hp += Convert.ToInt32(Mathf.Round(maxhp * percentOfHeal));
                timeHeal = 0;
            }
            else
            {
                hp = maxhp;
                timeStartHeal = 0;
            }
            HPtext.text = hp.ToString();
            HPslide.transform.localScale = new Vector3((float)(hp) / maxhp , HPslide.transform.localScale.y, HPslide.transform.localScale.z);
            float newPosX = -(1f - HPslide.transform.localScale.x) / 2;
            HPslide.transform.localPosition = new Vector3(newPosX, HPslide.transform.localPosition.y, 0f);
        }
    }

    public void Reload()
    {
        if (ammo < maxammo)
        {
            timeReload += Time.deltaTime;
            if (timeReload >= reloadtime)
            {
                if (gameObject.transform.parent.GetComponent<PlayerMove>() != null)
                    AmmoList[ammo].transform.localScale = new Vector3((float)(1f / maxammo - 0.01), AmmoList[ammo].transform.localScale.y, AmmoList[ammo].transform.localScale.z);
                ammo += 1;
                timeReload = 0;
            }
        }
    }

    public void ShowHP()
    {
        HPtext.text = hp.ToString();
        HPtext.transform.position = Camera.main.WorldToScreenPoint(transform.position);
        HPtext.transform.position = new Vector3(HPtext.transform.position.x, (float)(HPtext.transform.position.y + Screen.height * 0.075), HPtext.transform.position.z);
    }

    public void SetAmmo()
    {
        if (gameObject.transform.parent.GetComponent<PlayerMove>() != null)
        {
            if (maxammo > 1)
            {
                float scaleAmmo = (float)(1f / maxammo - 0.01);
                float distanceBetweenPatrons = (float)(scaleAmmo + 0.04 / (maxammo - 1));
                float totalWidth = maxammo * distanceBetweenPatrons;
                float startX = -totalWidth / 2 + distanceBetweenPatrons / 2;
                for (int i = 0; i < maxammo; i++)
                {
                    AmmoList.Add(Instantiate(Ammoslide, transform.position, Quaternion.identity));
                    AmmoList[i].transform.parent = transform.parent;
                    AmmoList[i].transform.localScale = new Vector3(scaleAmmo, AmmoList[i].transform.localScale.y, AmmoList[i].transform.localScale.z);
                    float posX = startX + i * distanceBetweenPatrons;
                    AmmoList[i].transform.position = new Vector3(HPslide.transform.position.x + posX, HPslide.transform.position.y - HPslide.GetComponent<SpriteRenderer>().bounds.size.y, HPslide.transform.position.z);
                }
            }
            else
            {
                AmmoList.Add(Instantiate(Ammoslide, transform.position, Quaternion.identity));
                AmmoList[0].transform.parent = transform.parent;
                AmmoList[0].transform.position = new Vector3(HPslide.transform.position.x, HPslide.transform.position.y - HPslide.GetComponent<SpriteRenderer>().bounds.size.y, HPslide.transform.position.z);
                AmmoBackground.transform.localScale = AmmoList[0].transform.localScale;
            }
        }
    }

    public void CollectSuper(float Count)
    {
        bulletforsuper += Count;
        if (bulletforsuper >= countbulletforsuper)
        {
            if (!isSuperReady)
            {
                if (playerMove != null)
                {
                    playerMove.staticJosticSuperObject.SetSiblingIndex(playerMove.staticJosticSuperObject.GetSiblingIndex() + 1);

                    playerMove.staticJosticSuper.colorHandle = playerMove.staticJosticSuper.background.GetComponent<Image>().color;
                    playerMove.staticJosticSuper.colorHandle.a = 0.5f;
                    playerMove.staticJosticSuper.background.GetComponent<Image>().color = playerMove.staticJosticSuper.colorHandle;
                    playerMove.staticJosticSuper.handle.GetComponent<Image>().color = Color.yellow;
                }

                isSuperReady = true;
                Cirle_supre.SetActive(true);
            }
        }
    }
}
