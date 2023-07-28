using System;
using UnityEngine;

public class Nita : MyHero
{
    public Spawn_attack_Nita spawn_Attack_Nita;
    public Spawn_super_Nita spawn_Super_Nita;

    public override void Start()
    {
        lvl = 1;
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
                spawn_Attack_Nita.Attack(angle);
                timeAttack = 0;
            }
        }
    }

    public override void Super(float angle)
    {
        base.Attack(angle);
        if (isSuperReady)
        {
            spawn_Super_Nita.Attack(angle);
            isSuperReady = false;
            Cirle_supre.SetActive(false);
            playerMove.staticJosticSuperObject.SetSiblingIndex(playerMove.staticJosticSuperObject.GetSiblingIndex() - 1);
            bulletforsuper = 0;
        }
    }
}
