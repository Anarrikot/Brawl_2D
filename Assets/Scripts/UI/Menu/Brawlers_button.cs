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

    public void onClick()
    {
        foreach (Brawler brawler in PlayerInfo.Instance.myBrawlers.listBrawlers)
        {
            if (nameBrawler.text == brawler.name)
            {
                PlayerInfo.Instance.activeBravler = brawler;
                CSVcontroller.Instance.SaveActiveBrawler(brawler);
                Menu.Instance.SetActiveBrawler(brawler);
                FindObjectOfType<ComonWindow>().Close();
                return;
            }
        }
    }

}
