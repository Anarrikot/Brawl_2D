using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public Brawlers myBrawlers = new Brawlers();

    private static PlayerInfo _instance;
    public static PlayerInfo Instance
        => _instance ??= new PlayerInfo();

    public PlayerInfo()
    {
        _instance = this;
    }

    public void Start()
    {
    }

    public void GetInfo()
    {
        foreach (Brawler brawler in myBrawlers.listBrawlers)
        {
            if (brawler.unlock == true)
                continue;
            brawler.power = 1;
            brawler.trophi = 0;
            brawler.unlock = false;
        }
    }
}
