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
    public int countbulletforsuper;

    public GameObject HPslide;
    public Text HPtext;

    private float time;


    private static MyHero _instance;
    public static MyHero Instance
        => _instance ??= new MyHero();

    public MyHero()
    {
        _instance = this;
    }

    public virtual void Start()
    {
        HPtext.text = hp.ToString(); 
    }

    public virtual void Update()
    {
        ShowHP();
    }

    public virtual void Attack(float angle)
    {

    }
    
    public  void TakeDamage()
    {

    }

    public void Heal()
    {

    }

    public void Reload()
    {
        if (ammo < maxammo)
        {
            time += Time.deltaTime;
            if (time >= reloadtime)
            {
                ammo += 1;
                time = 0;
            }
        }
    }

    public void ShowHP()
    {
        HPtext.transform.position = Camera.main.WorldToScreenPoint(transform.position);
        HPtext.transform.position = new Vector3(HPtext.transform.position.x, (float)(HPtext.transform.position.y + 57.5), HPtext.transform.position.z);
    }
}
