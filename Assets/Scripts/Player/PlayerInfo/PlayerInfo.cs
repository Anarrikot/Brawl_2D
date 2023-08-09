using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public Brawlers myBrawlers = new Brawlers();
    CSVcontroller CSVcontrol = new CSVcontroller();

    public Brawler activeBravler;

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

    public PlayerInfo GetInfo()
    {
        PlayerInfo playerInfo = CSVcontrol.ReadCSV();
        CSVcontrol.Save(playerInfo);
        return playerInfo;
    }

    public Brawler GetInfoActiveBrawler()
    {
        Brawler activeBrawler = CSVcontrol.ReadCSVActiveBrawler();
        CSVcontrol.SaveActiveBrawler(activeBrawler);
        return activeBrawler;
    }
}