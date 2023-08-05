using System.Collections.Generic;
using UnityEngine;

public class WindowsController
{
    private GameObject myPrefab, myPrefab1;
    public List<GameObject> Prefabs = new List<GameObject>();
    private bool access = true;

    public void AddWindow(string name)
    {
        Prefabs.Add((GameObject)Resources.Load(name));
        OpenWindow();
    }

    public void OpenWindow()
    {
        if (Prefabs.Count != 0 && access)
        {
            myPrefab = Prefabs[0];
            myPrefab = Menu.Instantiate(myPrefab, Menu.Instance.windowCanvas.transform);
            myPrefab.GetComponent<ComonWindow>().Delegate(OpenNextWindow);
            Prefabs.RemoveAt(0);
            access = false;
        }
    }

    public GameObject OpenNow(string name)
    {
        Prefabs.Add((GameObject)Resources.Load(name));
        myPrefab = Prefabs[0];
        myPrefab = Menu.Instantiate(myPrefab, Menu.Instance.windowCanvas.transform);
        myPrefab.GetComponent<ComonWindow>().Delegate(OpenNextWindow);
        Prefabs.RemoveAt(0);
        return myPrefab;
    }

    public void OpenNextWindow()
    {
        access = true;
        OpenWindow();
    }
}