using UnityEngine;
using UnityEngine.UI;

public class Box : MonoBehaviour
{
    public int hp = 4500;
    public int maxhp = 4500;

    public GameObject HPslide;
    public Text HPtext;

    public void Start()
    {
        HPtext.text = hp.ToString();
    }

    public void Update()
    {
        ShowHP();
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
            Destroy(gameObject);
        else
        {
            HPslide.transform.localScale = new Vector3((float)(hp) / maxhp, HPslide.transform.localScale.y, HPslide.transform.localScale.z);
            float newPosX = -(1f - HPslide.transform.localScale.x) / 2;
            HPslide.transform.localPosition = new Vector3(newPosX, HPslide.transform.localPosition.y, 0f);
            HPtext.text = hp.ToString();
        }
    }

    public void ShowHP()
    {
        HPtext.transform.position = Camera.main.WorldToScreenPoint(transform.position);
        HPtext.transform.position = new Vector3(HPtext.transform.position.x, (float)(HPtext.transform.position.y + Screen.height * 0.07), HPtext.transform.position.z);
    }
}
