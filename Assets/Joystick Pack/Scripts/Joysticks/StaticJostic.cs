using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StaticJostic : Joystick
{
    public float MoveThreshold { get { return moveThreshold; } set { moveThreshold = Mathf.Abs(value); } }

    [SerializeField] private float moveThreshold = 1;
    Vector3 startPosition;
    float angle;
    public bool isActiveAttack;
    public bool isMoveHandle;
    Vector2 tapPosition;

    protected override void Start()
    {
        startPosition = background.transform.position;
        MoveThreshold = moveThreshold;
        base.Start();
        background.gameObject.SetActive(true);
        colorHandle = handle.GetComponent<Image>().color;
        colorHandle.a = 0.5f;
        handle.GetComponent<Image>().color = colorHandle;
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        isMoveHandle = false;
        isActiveAttack = true;
        background.anchoredPosition = ScreenPointToAnchoredPosition(eventData.position);
        base.OnPointerDown(eventData);
        tapPosition = ScreenPointToAnchoredPosition(eventData.position);
        colorHandle = handle.GetComponent<Image>().color;
        colorHandle.a = 1f;
        handle.GetComponent<Image>().color = colorHandle;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        background.transform.position = startPosition;
        if (tapPosition == ScreenPointToAnchoredPosition(eventData.position))
            playerMove.MyHero.Attack(angle, true);
        else if (isMoveHandle && tapPosition != ScreenPointToAnchoredPosition(eventData.position))
            playerMove.MyHero.Attack(angle, false);
        isActiveAttack = false;
        colorHandle = handle.GetComponent<Image>().color;
        colorHandle.a = 0.5f;
        handle.GetComponent<Image>().color = colorHandle;
    }

    protected override void HandleInput(float magnitude, Vector2 normalised, Vector2 radius, Camera cam)
    {
        if (magnitude > 0.2f)
        {
            isMoveHandle = true;
            isActiveAttack = true;
        }
        else
        {
            isMoveHandle = false;
            isActiveAttack = false;
        }
        base.HandleInput(magnitude, normalised, radius, cam);
        angle = Mathf.Atan2(Vertical, Horizontal) * Mathf.Rad2Deg;
    }
}
