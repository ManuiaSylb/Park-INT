using UnityEngine;

public class RotateChildrenOnX : MonoBehaviour
{
    public float rotationSpeed = 120f; // Vitesse de rotation en degrés par seconde

    void Update()
    {
        // Parcourir tous les enfants de l'objet parent
        foreach (Transform child in transform)
        {
            // Appliquer une rotation sur l'axe X
            child.Rotate(Vector3.right * rotationSpeed * Time.deltaTime, Space.Self);
        }
    }
}