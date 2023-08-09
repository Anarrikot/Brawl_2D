using UnityEngine;

public class RotateObject : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 previousMousePosition;
    private Rigidbody rb;

    public float rotationSpeed = 1000f;
    public float decelerationRate = 2f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.angularDrag = 0.5f; // Настройте этот параметр для достижения желаемого поведения замедления
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            previousMousePosition = Input.mousePosition;
            rb.angularVelocity = Vector3.zero; // Сброс скорости вращения при начале взаимодействия
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            Vector3 currentMousePosition = Input.mousePosition;
            float deltaX = currentMousePosition.x - previousMousePosition.x;

            // Изменение движения объекта по оси Y
            rb.AddTorque(Vector3.up * deltaX * rotationSpeed * Time.deltaTime);

            previousMousePosition = currentMousePosition;
        }

        // Замедление объекта с течением времени
        rb.angularVelocity *= decelerationRate;
    }
}
