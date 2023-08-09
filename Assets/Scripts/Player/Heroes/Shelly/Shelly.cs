using System;
using UnityEngine;

public class Shelly : MyHero
{
    public Spawn_attack_shelly spawn_Attack_Shelly;
    public Spawn_super_shelly spawn_Supper_Shelly;

    public override void Start()
    {
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
        isHiroAttackTrow = false;
        isHiroSuperTrow = false; 
        base.Start();
        spawn_Supper_Shelly.hero = this;
        spawn_Attack_Shelly.hero = this;
    }
    public override void Attack(float angle, bool isAvtoAttack)
    {
        base.Attack(angle, isAvtoAttack);
        if (ammo > 0)
        {
            if (timeAttack >= timedelayattack)
            {
                ammo -= 1;
                AmmoList[ammo].transform.localScale = new Vector3(0, AmmoList[ammo].transform.localScale.y, AmmoList[ammo].transform.localScale.z);
                spawn_Attack_Shelly.Attack(angleAttack);
                timeAttack = 0;
            }
        }
    }

    public override void Super(float angle, bool isAvtoAttack)
    {
        base.Super(angle, isAvtoAttack);
        if (isSuperReady)
        {
            spawn_Supper_Shelly.Attack(angleSuper);
            isSuperReady = false;
            Cirle_supre.SetActive(false);
            playerMove.staticJosticSuperObject.SetSiblingIndex(playerMove.staticJosticSuperObject.GetSiblingIndex() - 1);
            bulletforsuper = 0;
        }
    }
}
