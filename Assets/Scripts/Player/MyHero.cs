using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MyHero : MonoBehaviour 
{
    public int damage;
    public int ammo;
    public int maxammo;
    public int hp;
    public int maxhp;
    public float speed;
    public float reloadtime;
    public int lvl;
    public int bullets;
    public int bulletforsuper;
    public int countbulletforsuper;

    public bool isSuperReady = false;

    public GameObject HPslide;
    public Text HPtext;

    public GameObject Ammoslide;
    public List<GameObject> AmmoList;
    public GameObject AmmoBackground;

    private float timeReload;
    private float timeStartHeal;
    private float timeHeal;
    private float percentOfHeal = 0.13f;

    public PlayerMove playerMove;

    private static MyHero _instance;
    public static MyHero Instance
        => _instance ??= new MyHero();

    public MyHero()
    {
        _instance = this;
    }

    public virtual void Start()
    {
        SetAmmo();
        TakeDamage(1500);
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
    }

    public virtual void Attack(float angle)
    {
        timeHeal = 0;
        timeStartHeal = 0;
    }

    public virtual void Super(float angle)
    {
        timeHeal = 0;
        timeStartHeal = 0;
    }

    public  void TakeDamage(int damage)
    {
        hp -= damage;
        HPslide.transform.localScale = new Vector3((float)(hp) / maxhp, HPslide.transform.localScale.y, HPslide.transform.localScale.z);
        float newPosX = -(1f - HPslide.transform.localScale.x) / 2;
        HPslide.transform.localPosition = new Vector3(newPosX, HPslide.transform.localPosition.y, 0f);
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
            HPslide.transform.localScale = new Vector3((float)(hp) / maxhp, HPslide.transform.localScale.y, HPslide.transform.localScale.z);
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
                AmmoList[ammo].transform.localScale = new Vector3((float)(1f / maxammo - 0.01), AmmoList[ammo].transform.localScale.y, AmmoList[ammo].transform.localScale.z);
                ammo += 1;
                timeReload = 0;
            }
        }
    }

    public void ShowHP()
    {
        HPtext.transform.position = Camera.main.WorldToScreenPoint(transform.position);
        HPtext.transform.position = new Vector3(HPtext.transform.position.x, (float)(HPtext.transform.position.y + Screen.height * 0.075), HPtext.transform.position.z);
    }

    public void SetAmmo()
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

    public void CollectSuper(int Count)
    {
        bulletforsuper += Count;
        if (bulletforsuper >= countbulletforsuper)
        {
            if (!isSuperReady)
            {
                playerMove.staticJosticSuperObject.SetSiblingIndex(playerMove.staticJosticSuperObject.GetSiblingIndex() + 1);
                isSuperReady = true;
            }
        }
    }
}
