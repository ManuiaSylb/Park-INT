using UnityEngine;

public class CarController : MonoBehaviour
{
    private float horizontalInput, verticalInput;
    private float currentSteerAngle, currentbreakForce;
    private bool isBreaking;

    // Settings
    [SerializeField] private float motorForce, breakForce, maxSteerAngle;

    // Wheel Colliders
    private WheelCollider frontLeftWheelCollider, frontRightWheelCollider;
    private WheelCollider rearLeftWheelCollider, rearRightWheelCollider;

    // Wheels (Transforms)
    private Transform frontLeftWheelTransform, frontRightWheelTransform;
    private Transform rearLeftWheelTransform, rearRightWheelTransform;

    // Rigidbody (pour gérer la vitesse)
    private Rigidbody carRigidbody;

    private void Awake()
    {
        // Localiser les Wheel Colliders dans la hiérarchie
        frontLeftWheelCollider = transform.Find("Wheels/Colliders/FrontLeftWheel").GetComponent<WheelCollider>();
        frontRightWheelCollider = transform.Find("Wheels/Colliders/FrontRightWheel").GetComponent<WheelCollider>();
        rearLeftWheelCollider = transform.Find("Wheels/Colliders/RearLeftWheel").GetComponent<WheelCollider>();
        rearRightWheelCollider = transform.Find("Wheels/Colliders/RearRightWheel").GetComponent<WheelCollider>();

        // Localiser les Transforms des meshes des roues
        frontLeftWheelTransform = transform.Find("Wheels/Meshes/FrontLeftWheel");
        frontRightWheelTransform = transform.Find("Wheels/Meshes/FrontRightWheel");
        rearLeftWheelTransform = transform.Find("Wheels/Meshes/RearLeftWheel");
        rearRightWheelTransform = transform.Find("Wheels/Meshes/RearRightWheel");

        // Récupérer le Rigidbody
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

        // Calculer la vitesse longitudinale (positive si le véhicule avance, négative si le véhicule recule)
        float forwardSpeed = Vector3.Dot(carRigidbody.velocity, transform.forward);

        // Le freinage se produit uniquement si le joueur appuie sur "flèche arrière" (verticalInput < 0)
        // et que le véhicule se déplace vers l'avant (forwardSpeed > 0).
        isBreaking = (verticalInput < 0 && forwardSpeed > 0.1f) || Input.GetKey(KeyCode.Space);
    }

    private void HandleMotor()
    {
        if (verticalInput > 0) // Accélération normale
        {
            ApplyMotorTorque(verticalInput * motorForce);
            currentbreakForce = 0f;
        }
        else if (isBreaking) // Freinage
        {
            currentbreakForce = breakForce;
            ApplyMotorTorque(0f); // Pas de couple moteur pendant le freinage
        }
        else // Marche arrière (quand vitesse est nulle ou proche de zéro)
        {
            currentbreakForce = 0f;
            ApplyMotorTorque(verticalInput * motorForce); // Appliquer un couple négatif pour reculer
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