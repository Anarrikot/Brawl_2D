using System;
using UnityEngine;

public class Shelly : MyHero
{
    public Spawn_attack_shelly spawn_Attack_Shelly;
    public Spawn_super_shelly spawn_Supper_Shelly;

    public override void Start()
    {
        lvl = 1;
        bullets = 5;
        damage = Convert.ToInt32(Math.Round(300 + 300 * 0.05 * (lvl - 1)));
        damageSuper = Convert.ToInt32(Math.Round(320 + 320 * 0.05 * (lvl - 1)));
        ammo = 3;
        maxammo = 3;
        hp = Convert.ToInt32(Math.Round(3700 + 3700 * 0.05 * (lvl - 1)));
        maxhp = hp;
        reloadtime = 1.2f;
        countbulletforsuper = 10;
        timedelayattack = 0.4f;
        base.Start();
    }
    public override void Attack(float angle)
    {
        base.Attack(angle);
        if (ammo > 0)
        {
            if (timeAttack >= timedelayattack)
            {
                ammo -= 1;
                AmmoList[ammo].transform.localScale = new Vector3(0, AmmoList[ammo].transform.localScale.y, AmmoList[ammo].transform.localScale.z);
                spawn_Attack_Shelly.Attack(angle);
                timeAttack = 0;
            }
        }
    }

    public override void Super(float angle)
    {
        base.Attack(angle);
        if (isSuperReady)
        {
            spawn_Supper_Shelly.Attack(angle);
            isSuperReady = false;
            Cirle_supre.SetActive(false);
            playerMove.staticJosticSuperObject.SetSiblingIndex(playerMove.staticJosticSuperObject.GetSiblingIndex() - 1);
            bulletforsuper = 0;
        }
    }
}
