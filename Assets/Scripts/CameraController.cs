using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform car;
    public float rotationSpeed = 1000f;
    public float verticalLimit = 89f;
    public float radius = 5f;
    public float hemisphereYOffset = 1f;
    public float scrollSpeed = 1f;
    public float minRadius = 5f;
    public float maxRadius = 10f;

    private float currentVerticalAngle = 20f;
    private float currentHorizontalAngle = 0f;

    private Vector3 initialPosition;
    private Quaternion initialRotation;

    void Start()
    {
        UpdateCameraPosition();
        initialPosition = transform.position;
        initialRotation = transform.rotation;
        
    }

    void Update()
    {
        HandleMouseInput();
        UpdateCameraPosition();

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            ResetCameraPosition();
        }
    }

    private void HandleMouseInput()
    {
        if (Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            currentHorizontalAngle += mouseX * rotationSpeed * Time.deltaTime;
            currentVerticalAngle -= mouseY * rotationSpeed * Time.deltaTime;

            currentVerticalAngle = Mathf.Clamp(currentVerticalAngle, 0f, verticalLimit);
        }

        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        if (scrollInput != 0)
        {
            radius -= scrollInput * scrollSpeed;
            radius = Mathf.Clamp(radius, minRadius, maxRadius);
        }
    }

    private void UpdateCameraPosition()
    {
        Quaternion carRotation = car.rotation;

        Quaternion rotation = Quaternion.Euler(currentVerticalAngle, currentHorizontalAngle, 0);
        Vector3 offset = rotation * new Vector3(0, 0, -radius);
        Vector3 orbitCenter = car.position + new Vector3(0, hemisphereYOffset, 0);

        transform.position = orbitCenter + carRotation * offset;
        transform.LookAt(orbitCenter);
    }

    private void ResetCameraPosition()
    {
        transform.position = initialPosition;
        transform.rotation = initialRotation;

        currentHorizontalAngle = 0f;
        currentVerticalAngle = 20f;

        UpdateCameraPosition();
    }
}