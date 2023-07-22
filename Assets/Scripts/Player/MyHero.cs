using UnityEngine;

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

    private float time;


    private static MyHero _instance;
    public static MyHero Instance
        => _instance ??= new MyHero();

    public MyHero()
    {
        _instance = this;
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
}
