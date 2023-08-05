using UnityEngine;

public class ComonWindow : MonoBehaviour
{
    public delegate void NextWindow();
    public NextWindow nextWindow;
    public void Delegate(NextWindow next)
    {
        nextWindow = next;
    }
    public void Start()
    {
        Time.timeScale = 0;
    }
    public void Close()
    {
        nextWindow();
        Time.timeScale = 1;
        Destroy(gameObject);
    }

}
