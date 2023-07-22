using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelly : MyHero
{
    public Spawn_attack_shelly spawn_Attack_Shelly;

    public void Start()
    {
        bullets = 5;
        damage = 300;
        lvl = 1;
        ammo = 3;
        maxammo = 3;
        hp = 3700;
        maxhp = hp;
        reloadtime = 1;
        
    }
    public void Update()
    {
        Reload();
    }

    public override void Attack(float angle)
    {
        if (ammo > 0)
        {
            ammo -= 1;
            spawn_Attack_Shelly.Attack(angle);
        }
    }
}
