using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelly : MyHero
{
    public Spawn_attack_shelly spawn_Attack_Shelly;
    public Spawn_super_shelly spawn_Supper_Shelly;

    public override void Start()
    {
        bullets = 5;
        damage = 300;
        lvl = 1;
        ammo = 3;
        maxammo = 3;
        hp = 3700;
        maxhp = hp;
        reloadtime = 1;
        countbulletforsuper = 10;
        base.Start();
    }
    public override void Update()
    {
        base.Update();
        Reload();
    }

    public override void Attack(float angle)
    {
        base.Attack(angle);
        if (ammo > 0)
        {
            ammo -= 1;
            AmmoList[ammo].transform.localScale = new Vector3 (0, AmmoList[ammo].transform.localScale.y, AmmoList[ammo].transform.localScale.z);
            spawn_Attack_Shelly.Attack(angle);
        }
    }

    public override void Super(float angle)
    {
        base.Attack(angle);
        if (isSuperReady)
        {
            spawn_Supper_Shelly.Attack(angle);
            isSuperReady = false;
            playerMove.staticJosticSuperObject.SetSiblingIndex(playerMove.staticJosticSuperObject.GetSiblingIndex() - 1);
            bulletforsuper = 0;
        }
    }
}
