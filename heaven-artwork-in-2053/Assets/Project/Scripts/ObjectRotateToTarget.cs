using UnityEngine;

public class ObjectRotateToTarget : MonoBehaviour
{
    // Define variables
    public Transform target;
    public float rotationSpeed = 1.0f;

    void Update()
    {
        // Get target direction
        Vector3 targetDirection = target.position - transform.position;
        float singleStep = rotationSpeed * Time.deltaTime;

        // Calculate new direction and turn the object trasnform to that direction
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }
}
