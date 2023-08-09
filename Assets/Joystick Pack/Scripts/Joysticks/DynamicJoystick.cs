using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DynamicJoystick : Joystick
{
    public float MoveThreshold { get { return moveThreshold; } set { moveThreshold = Mathf.Abs(value); } }

    [SerializeField] private float moveThreshold = 1;
    Vector3 startPosition;

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
        background.anchoredPosition = ScreenPointToAnchoredPosition(eventData.position);
        base.OnPointerDown(eventData);
        colorHandle = handle.GetComponent<Image>().color;
        colorHandle.a = 1f;
        handle.GetComponent<Image>().color = colorHandle;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        background.transform.position = startPosition;
        colorHandle = handle.GetComponent<Image>().color;
        colorHandle.a = 0.5f;
        handle.GetComponent<Image>().color = colorHandle;
    }

    protected override void HandleInput(float magnitude, Vector2 normalised, Vector2 radius, Camera cam)
    {
        if (magnitude > moveThreshold)
        {
            Vector2 difference = normalised * (magnitude - moveThreshold) * radius;
            background.anchoredPosition += difference;
        }
        base.HandleInput(magnitude, normalised, radius, cam);
    }
}