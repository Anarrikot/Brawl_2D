using System;
using System.IO;
using UnityEngine;
using System.Collections.Generic;

public class CSVcontroller : MonoBehaviour
{

    string filenameInfoBrawlers;
    string filenameInfoActiveBrawler;

    private static CSVcontroller _instance;
    public static CSVcontroller Instance
        => _instance ??= new CSVcontroller();

    public CSVcontroller()
    {
        _instance = this;
    }

    private void Awake()
    {
        filenameInfoBrawlers = Application.persistentDataPath + "/Brawlers.csv";
        filenameInfoActiveBrawler = Application.persistentDataPath + "/ActiveBrawler.csv";
    }

    public void Save(PlayerInfo player)
    {
        filenameInfoBrawlers = Application.persistentDataPath + "/Brawlers.csv";
        TextWriter tw = new StreamWriter(filenameInfoBrawlers);
        for (int i = 0; i < player.myBrawlers.listBrawlers.Count; i++)
        {
            tw.WriteLine(player.myBrawlers.listBrawlers[i].name + "," + player.myBrawlers.listBrawlers[i].id + "," +
                player.myBrawlers.listBrawlers[i].unlock + "," + player.myBrawlers.listBrawlers[i].trophi + "," + 
                player.myBrawlers.listBrawlers[i].power);
        }
        tw.Close();
    }

    public PlayerInfo ReadCSV()
    {
        PlayerInfo playerInfo = new PlayerInfo();
        filenameInfoBrawlers = Application.persistentDataPath + "/Brawlers.csv";
        TextReader tw = new StreamReader(filenameInfoBrawlers);
        string line;
        string[] words;
        int number = 0;
        while ((line = tw.ReadLine()) != null)
        {
            words = line.Split(',');
            playerInfo.myBrawlers.listBrawlers[number].unlock = Convert.ToBoolean(words[2]);
            playerInfo.myBrawlers.listBrawlers[number].trophi = Convert.ToInt32(words[3]);
            playerInfo.myBrawlers.listBrawlers[number].power = Convert.ToInt32(words[4]);
            number++;
        }
        tw.Close();
        SaveActiveBrawler(new Brawler() { name = "ØÅËËÈ", id = 0, unlock = true, power = 1, trophi = 0 });
        return playerInfo;
    }

    public void SaveActiveBrawler(Brawler activeBrawler)
    {
        filenameInfoActiveBrawler = Application.persistentDataPath + "/ActiveBrawler.csv";
        TextWriter tw = new StreamWriter(filenameInfoActiveBrawler);
        tw.WriteLine(activeBrawler.name + "," + activeBrawler.id + "," +
                activeBrawler.unlock + "," + activeBrawler.trophi + "," +
                activeBrawler.power);
        tw.Close();
    }

    public Brawler ReadCSVActiveBrawler()
    {
        Brawler activeBrawler = new Brawler();
        filenameInfoActiveBrawler = Application.persistentDataPath + "/ActiveBrawler.csv";
        TextReader tw = new StreamReader(filenameInfoActiveBrawler);
        string line = tw.ReadLine();
        string[] words = line.Split(',');
        activeBrawler.name = words[0];
        activeBrawler.unlock = Convert.ToBoolean(words[2]);
        activeBrawler.trophi = Convert.ToInt32(words[3]);
        activeBrawler.power = Convert.ToInt32(words[4]);
        tw.Close();
        return activeBrawler;
    }
}
