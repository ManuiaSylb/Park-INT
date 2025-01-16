using UnityEngine;
using UnityEngine.SceneManagement;

public class ParkingZone : MonoBehaviour
{
    public WheelCollider frontLeftWheelCollider;
    public WheelCollider frontRightWheelCollider;
    public WheelCollider rearLeftWheelCollider;
    public WheelCollider rearRightWheelCollider;

    public int currentLevel;
    public LevelButtonController levelButtonController; 

    private bool isFullyInZone = false;
    private float timer = 0f;
    private const float requiredTimeInZone = 2f;
    public GameObject Canvas_0;
    public GameObject Canvas_1;
    public GameObject Canvas_2;
    public GameObject Canvas_3;
    public GameObject Canvas_4;


    void Start()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex - 1;

        Canvas_4.SetActive(false);

    }

    void Update()
    {
        if (isFullyInZone)
        {
            timer += Time.deltaTime;

            if (timer >= requiredTimeInZone)
            {
                ValidateLevel();
                Time.timeScale = 0f;
                Canvas_0.SetActive(false);
                Canvas_1.SetActive(false);
                Canvas_2.SetActive(false);
                Canvas_3.SetActive(false);
                Canvas_4.SetActive(true);
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

    private void ValidateLevel()
    {
        PlayerPrefs.SetInt("Level" + currentLevel + "Validated", 1);
        PlayerPrefs.Save();

        if (levelButtonController != null)
        {
            levelButtonController.ValidateLevel();
        }
    }
}