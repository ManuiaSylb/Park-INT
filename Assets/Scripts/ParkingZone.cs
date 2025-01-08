using UnityEngine;

public class ParkingZone : MonoBehaviour
{
    public WheelCollider frontLeftWheelCollider;  // Référence au WheelCollider avant gauche
    public WheelCollider frontRightWheelCollider; // Référence au WheelCollider avant droit
    public WheelCollider rearLeftWheelCollider;   // Référence au WheelCollider arrière gauche
    public WheelCollider rearRightWheelCollider;  // Référence au WheelCollider arrière droit
    public float timeToComplete = 3f;
    private float timer = 0f;
    private bool isFullyInZone = false;

    void Update()
    {
        if (isFullyInZone)
        {
            timer += Time.deltaTime;

            if (timer >= timeToComplete)
            {
                Debug.Log("Bien joué");
                isFullyInZone = false;  // Réinitialiser pour ne pas afficher plusieurs fois
            }
        }
        else
        {
            timer = 0f;  // Réinitialiser le timer si la voiture n'est pas complètement dans la zone
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (CheckIfCarIsFullyInZone())
        {
            isFullyInZone = true;
        }
        else
        {
            isFullyInZone = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        isFullyInZone = false;
        timer = 0f;
    }

    private bool CheckIfCarIsFullyInZone()
    {
        if (!IsWheelInsideTrigger(frontLeftWheelCollider)) return false;
        if (!IsWheelInsideTrigger(frontRightWheelCollider)) return false;
        if (!IsWheelInsideTrigger(rearLeftWheelCollider)) return false;
        if (!IsWheelInsideTrigger(rearRightWheelCollider)) return false;

        return true;  // Toutes les roues sont à l'intérieur du trigger
    }

    private bool IsWheelInsideTrigger(WheelCollider wheel)
    {
        Vector3 wheelPosition = wheel.transform.position;
        Collider[] hitColliders = Physics.OverlapSphere(wheelPosition, wheel.radius);  // Vérifie la position de la roue avec un rayon

        foreach (Collider hitCollider in hitColliders)
        {
            if (hitCollider == this.GetComponent<Collider>())
            {
                return true;  // La roue est à l'intérieur du trigger
            }
        }

        return false;  // La roue n'est pas dans la zone
    }
}