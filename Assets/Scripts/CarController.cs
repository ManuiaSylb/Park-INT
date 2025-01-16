using UnityEngine;

public class CarController : MonoBehaviour
{
    private float horizontalInput, verticalInput;
    private float currentSteerAngle, currentbreakForce;
    private bool isBreaking;
    private float reverseDelayTimer = 0f;
    private bool isReversing = false;

    [SerializeField] private float motorForce, breakForce, maxSteerAngle, reverseDelay = 0.5f;

    private WheelCollider frontLeftWheelCollider, frontRightWheelCollider;
    private WheelCollider rearLeftWheelCollider, rearRightWheelCollider;

    private Transform frontLeftWheelTransform, frontRightWheelTransform;
    private Transform rearLeftWheelTransform, rearRightWheelTransform;

    private Rigidbody carRigidbody;

    private void Awake()
    {
        frontLeftWheelCollider = transform.Find("Wheels/Colliders/FrontLeftWheel").GetComponent<WheelCollider>();
        frontRightWheelCollider = transform.Find("Wheels/Colliders/FrontRightWheel").GetComponent<WheelCollider>();
        rearLeftWheelCollider = transform.Find("Wheels/Colliders/RearLeftWheel").GetComponent<WheelCollider>();
        rearRightWheelCollider = transform.Find("Wheels/Colliders/RearRightWheel").GetComponent<WheelCollider>();

        frontLeftWheelTransform = transform.Find("Wheels/Meshes/FrontLeftWheel");
        frontRightWheelTransform = transform.Find("Wheels/Meshes/FrontRightWheel");
        rearLeftWheelTransform = transform.Find("Wheels/Meshes/RearLeftWheel");
        rearRightWheelTransform = transform.Find("Wheels/Meshes/RearRightWheel");

        carRigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        float forwardSpeed = Vector3.Dot(carRigidbody.velocity, transform.forward);

        if ((verticalInput < 0 && forwardSpeed > 0.1f) || (verticalInput > 0 && forwardSpeed < -0.1f))
        {
            isReversing = true;
            reverseDelayTimer = reverseDelay;
        }

        if (isReversing)
        {
            reverseDelayTimer -= Time.fixedDeltaTime;
            if (reverseDelayTimer <= 0f)
                isReversing = false;
        }

        isBreaking = isReversing || Input.GetKey(KeyCode.Space);
    }

    private void HandleMotor()
    {
        if (isBreaking)
        {
            currentbreakForce = breakForce;
            ApplyMotorTorque(0f);
        }
        else
        {
            currentbreakForce = 0f;
            ApplyMotorTorque(verticalInput * motorForce);
        }

        ApplyBreaking();
    }

    private void ApplyMotorTorque(float torque)
    {
        frontLeftWheelCollider.motorTorque = torque;
        frontRightWheelCollider.motorTorque = torque;
    }

    private void ApplyBreaking()
    {
        frontRightWheelCollider.brakeTorque = currentbreakForce;
        frontLeftWheelCollider.brakeTorque = currentbreakForce;
        rearLeftWheelCollider.brakeTorque = currentbreakForce;
        rearRightWheelCollider.brakeTorque = currentbreakForce;
    }

    private void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }


}