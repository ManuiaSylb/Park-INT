using UnityEngine;

public class LifeManager : MonoBehaviour
{
    public int PV = 100;
    private bool hasCollided = false;

    public GameObject Canvas_0;
    public GameObject Canvas_1;
    public GameObject Canvas_2;
    public GameObject Canvas_3;
    public GameObject Canvas_4;

    void Start()
    {
        Canvas_3.SetActive(false);
        Canvas_4.SetActive(false);
    }

    void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Obstacles") && !hasCollided)
        {
            PV -= 20;
            hasCollided = true;

            if (PV <= 0)
            {   
                Time.timeScale = 0f;
                Canvas_0.SetActive(false);
                Canvas_1.SetActive(false);
                Canvas_2.SetActive(false);
                Canvas_3.SetActive(true);
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Obstacles"))
        {
            hasCollided = false;
        }
    }
}