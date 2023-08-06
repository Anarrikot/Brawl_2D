using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public WindowsController WindowController;
    public static Menu Instance = null;
    public Canvas windowCanvas;

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
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void ButtonBrawlers()
    {
        WindowController.AddWindow("Prefabs/Menu/Brawlers");
    }
}
