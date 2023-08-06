using UnityEngine;
using UnityEngine.UI;

public class Brawlers_button : MonoBehaviour
{
    public Text nameBrawler;
    public Text powerBrawler;
    public Text countTrophi;
    public Text rang;
    public Image backgroundRang;
    public Image imageBrawler;

    public Brawlers_button(string name, int power, int trophi)
    {
        nameBrawler.text = name;
        powerBrawler.text = power.ToString();
        countTrophi.text = trophi.ToString();
    }

    public Brawlers_button(string name)
    {
        nameBrawler.text = name;
    }
}
