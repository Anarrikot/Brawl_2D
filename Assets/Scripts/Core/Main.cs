using UnityEngine;

public class Main : MonoBehaviour
{
    public static Main Instance = null;

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
    }
}
