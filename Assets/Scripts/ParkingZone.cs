using UnityEngine;

public class ParkingZone : MonoBehaviour
{
    public WheelCollider frontLeftWheelCollider;  
    public WheelCollider frontRightWheelCollider; 
    public WheelCollider rearLeftWheelCollider;   
    public WheelCollider rearRightWheelCollider; 
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
                isFullyInZone = false;  
            }
        }
        else
        {
            timer = 0f;  
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

        return true;  
    }

    private bool IsWheelInsideTrigger(WheelCollider wheel)
    {
        Vector3 wheelPosition = wheel.transform.position;
        Collider[] hitColliders = Physics.OverlapSphere(wheelPosition, wheel.radius);  

        foreach (Collider hitCollider in hitColliders)
        {
            if (hitCollider == this.GetComponent<Collider>())
            {
                return true;  
            }
        }

        return false;  
    }
}