using System;
using UnityEngine;

public class Nita : MyHero
{
    public Spawn_attack_Nita spawn_Attack_Nita;
    public Spawn_super_Nita spawn_Super_Nita;
    public Bear_NIta myBear;

    public override void Start()
    {
        bullets = 1;
        damage = Convert.ToInt32(Math.Round(960 + 960 * 0.05 * (lvl - 1)));
        damageSuper = Convert.ToInt32(Math.Round(400 + 400 * 0.05 * (lvl - 1)));
        ammo = 3;
        maxammo = 3;
        hp = Convert.ToInt32(Math.Round(4000 + 4000 * 0.05 * (lvl - 1)));
        maxhp = hp;
        reloadtime = 1.2f;
        countbulletforsuper = 5;
        timedelayattack = 0.4f;
        isHiroAttackTrow = false;
        isHiroSuperTrow = true;
        base.Start();

        spawn_Attack_Nita.hero = this;
        spawn_Super_Nita.lvlHero = lvl;
        spawn_Super_Nita.nita = this;
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
                spawn_Attack_Nita.Attack(angleAttack);
                timeAttack = 0;
            }
        }
    }

    public override void Super(float angle, bool isAvtoAttack)
    {
        base.Super(angle, isAvtoAttack);
        if (isSuperReady)
        {
            if (isAvtoAttack)  
                spawn_Super_Nita.Attack(angleSuper, true);
            else
                spawn_Super_Nita.Attack(angleSuper, false);
            isSuperReady = false;
            Cirle_supre.SetActive(false);
            playerMove.staticJosticSuperObject.SetSiblingIndex(playerMove.staticJosticSuperObject.GetSiblingIndex() - 1);
            bulletforsuper = 0;
        }
    }
}
