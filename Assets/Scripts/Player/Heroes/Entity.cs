using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Entity : MonoBehaviour
{
    public int lvl_hero;
    public int hp;
    public int maxhp;
    public int damage;
    public float speed;
    public float timeDelayAttack;

    public Rigidbody2D rb;

    public NavMeshAgent agent;

    public GameObject HPslide;
    public Text HPtext;

    public MyHero myHero;

    public GameObject Cirle;

    public float timeAttack;

    public void TakeDamage(int damage)
    {
        hp -= damage;
        HPslide.transform.localScale = new Vector3((float)(hp) / maxhp, HPslide.transform.localScale.y, HPslide.transform.localScale.z);
        float newPosX = -(1f - HPslide.transform.localScale.x) / 2;
        HPslide.transform.localPosition = new Vector3(newPosX, HPslide.transform.localPosition.y, 0f);
    }

    public virtual void Start()
    {
        HPtext.text = hp.ToString();

        if (myHero.transform.parent.CompareTag("Enemy"))
        {
            HPslide.GetComponent<SpriteRenderer>().color = Color.red;
            Cirle.GetComponent<SpriteRenderer>().color = Color.red;
            tag = "Enemy";
        }
        else if (myHero.transform.parent.CompareTag("Teammate"))
        {
            HPslide.GetComponent<SpriteRenderer>().color = Color.blue;
            Cirle.GetComponent<SpriteRenderer>().color = Color.blue;
            tag = "Teammate";
        }
        else
            tag = "Player";
        rb = GetComponent<Rigidbody2D>();
    }

    public virtual void Update()
    {
        ShowHP();
        timeAttack += Time.deltaTime;
        rb.WakeUp();
    }

    public void ShowHP()
    {
        HPtext.transform.position = Camera.main.WorldToScreenPoint(transform.position);
        HPtext.transform.position = new Vector3(HPtext.transform.position.x, (float)(HPtext.transform.position.y + Screen.height * 0.06), HPtext.transform.position.z);
    }
}
