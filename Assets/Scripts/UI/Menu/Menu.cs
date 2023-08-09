using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{

    public WindowsController WindowController;
    public static Menu Instance = null;
    public Canvas windowCanvas;
    public Button activeBrawler;
    public Text power;
    public Text countTrophi;
    public Text rang;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance == this)
        {
            Destroy(gameObject);
        }

        WindowController = new WindowsController();

        string filenameInfoBrawlers = Application.persistentDataPath + "/Brawlers.csv";

        if (!File.Exists(filenameInfoBrawlers))
        {
            TextWriter tw = new StreamWriter(filenameInfoBrawlers);
            for (int i = 0; i < PlayerInfo.Instance.myBrawlers.listBrawlers.Count; i++)
            {
                tw.WriteLine(PlayerInfo.Instance.myBrawlers.listBrawlers[i].name + "," + PlayerInfo.Instance.myBrawlers.listBrawlers[i].id + "," +
                    "True" + "," + "200" + "," +
                    "1");
            }
            tw.Close();
        }

        string filenameInfoActiveBrawler = Application.persistentDataPath + "/ActiveBrawler.csv";

        if (!File.Exists(filenameInfoActiveBrawler))
        {
            TextWriter tw = new StreamWriter(filenameInfoActiveBrawler);
            tw.WriteLine(PlayerInfo.Instance.myBrawlers.listBrawlers[0].name + "," + PlayerInfo.Instance.myBrawlers.listBrawlers[0].id + "," +
                     "True" + "," + "200" + "," +
                     "1");
            tw.Close();
        }

        SetActiveBrawler(CSVcontroller.Instance.ReadCSVActiveBrawler());
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void ButtonBrawlers()
    {
        WindowController.AddWindow("Prefabs/Menu/Brawlers");
    }

    public void SetActiveBrawler(Brawler activebrawler)
    {
        activeBrawler.image.sprite = Resources.Load<Sprite>("Sprites/Menu/menu_brawler/" + activebrawler.name);
        power.text = activebrawler.power.ToString();
        countTrophi.text = activebrawler.trophi.ToString();
    }
}
