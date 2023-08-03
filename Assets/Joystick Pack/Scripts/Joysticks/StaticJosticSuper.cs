using UnityEngine;
using UnityEngine.EventSystems;

public class StaticJosticSuper : Joystick
{
    public float MoveThreshold { get { return moveThreshold; } set { moveThreshold = Mathf.Abs(value); } }

    [SerializeField] private float moveThreshold = 1;
    Vector3 startPosition;
    float angle;
    public bool isActiveSuper;
    public bool isMoveHandle;
    Vector2 tapPosition;
    public float magnitudeSuper;

    protected override void Start()
    {
        startPosition = background.transform.position;
        MoveThreshold = moveThreshold;
        base.Start();
        background.gameObject.SetActive(true);
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        isMoveHandle = false;
        isActiveSuper = true;
        background.anchoredPosition = ScreenPointToAnchoredPosition(eventData.position);
        base.OnPointerDown(eventData);
        tapPosition = ScreenPointToAnchoredPosition(eventData.position);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        background.transform.position = startPosition;
        if (tapPosition == ScreenPointToAnchoredPosition(eventData.position))
            MyHero.Instance.Super(angle, true);
        else if (isMoveHandle && tapPosition != ScreenPointToAnchoredPosition(eventData.position))
            MyHero.Instance.Super(angle, false);
        isActiveSuper = false;
    }

    protected override void HandleInput(float magnitude, Vector2 normalised, Vector2 radius, Camera cam)
    {
        if (magnitude > 1)
            magnitudeSuper = 1;
        else
            magnitudeSuper = magnitude;
        if (magnitude > 0.2f)
        {
            isMoveHandle = true;
            isActiveSuper = true;
        }
        else
        {
            isMoveHandle = false;
            isActiveSuper = false;
        }
        base.HandleInput(magnitude, normalised, radius, cam);
        angle = Mathf.Atan2(Vertical, Horizontal) * Mathf.Rad2Deg;
    }
}
