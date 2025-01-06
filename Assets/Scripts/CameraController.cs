using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform car;
    public float radius = 5f;
    public float rotationSpeed = 100f;
    public float verticalLimit = 90f;

    private float currentVerticalAngle = 30f;
    private float currentHorizontalAngle = 0f;

    void Start()
    {
        transform.position = new Vector3(0, 3f, -5f);
        transform.rotation = Quaternion.Euler(30f, 0f, 0f);
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            currentHorizontalAngle += mouseX * rotationSpeed * Time.deltaTime;
            currentVerticalAngle -= mouseY * rotationSpeed * Time.deltaTime;

            currentVerticalAngle = Mathf.Clamp(currentVerticalAngle, -verticalLimit, verticalLimit);

            Quaternion rotation = Quaternion.Euler(currentVerticalAngle, currentHorizontalAngle, 0);
            Vector3 position = car.position + rotation * new Vector3(0, 0, -radius);

            transform.position = position;
            transform.LookAt(car);
        }
    }
}