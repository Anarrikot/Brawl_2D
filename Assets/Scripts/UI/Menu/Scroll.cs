using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Scroll : MonoBehaviour
{
    public GameObject unlockBrawlers;
    public GameObject lockBrawlers;
    public GameObject separator;
    public Brawlers_button prefabButton;

    List<Brawlers_button> unlockBrawlersButton = new List<Brawlers_button>();
    List<Brawlers_button> lockBrawlersButton = new List<Brawlers_button>();

    private void Start()
    {
        PlayerInfo player = PlayerInfo.Instance.GetInfo();
        foreach (Brawler brawler in player.myBrawlers.listBrawlers)
        {
            if (brawler.unlock)
            {
                Brawlers_button button = Instantiate(prefabButton, unlockBrawlers.transform);
                button.nameBrawler.text = brawler.name;
                button.powerBrawler.text = brawler.power.ToString();
                button.countTrophi.text = brawler.trophi.ToString();
                button.imageBrawler.sprite = Resources.Load<Sprite>("Sprites/Menu/menu_brawler/" + brawler.name);
                unlockBrawlersButton.Add(button);
            }
            else
            {
                Brawlers_button button = Instantiate(prefabButton, lockBrawlers.transform);
                button.nameBrawler.text = brawler.name;
                lockBrawlersButton.Add(button);
            }
        }

        if (lockBrawlersButton.Count == 0)
            separator.SetActive(false);
    }
}
