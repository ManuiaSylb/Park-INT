using UnityEngine;
using System.Collections;

public class RotateAroundPoint : MonoBehaviour
{
    public Transform centerPoint;
    public float radius = 10f;
    public float rotationSpeed = 20f;
    public float stopDuration = 3f;

    private float angle = 0f;
    private bool isStopped = false;

    void Update()
    {
        if (isStopped) return;

        angle += rotationSpeed * Time.deltaTime * Mathf.Deg2Rad;

        float x = centerPoint.position.x + radius * Mathf.Cos(angle);
        float z = centerPoint.position.z + radius * Mathf.Sin(angle);
        transform.position = new Vector3(x, transform.position.y, z);

        Vector3 direction = (transform.position - centerPoint.position).normalized;
        transform.rotation = Quaternion.LookRotation(new Vector3(-direction.z, 0, direction.x));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider is BoxCollider)
        {
            StartCoroutine(StopRotationTemporarily());
        }
    }

    private IEnumerator StopRotationTemporarily()
    {
        isStopped = true;
        yield return new WaitForSeconds(stopDuration);
        isStopped = false;
    }
}