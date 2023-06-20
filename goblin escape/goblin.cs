using UnityEngine;

public class Goblin : MonoBehaviour
{
    public Transform centerObject; // circle position
    public float speed;

    private float radius; // radius the goblin can rotates

    private void Start()
    {
        radius = centerObject.localScale.x * 0.5f;
    }

    private void Update()
    {
        GameObject targetObject = GameObject.FindGameObjectWithTag("Player");
        
        // calculates the direction of 'targetObject' relative to 'centerObject'
        Vector3 direction = targetObject.transform.position - centerObject.position;
        direction.Normalize();

        // calculates the desired position on the circumference of the circle
        Vector3 desiredPosition = centerObject.position + direction * radius;

        // calculates the rotation speed based on the distance between the attached object and the desired position
        float distance = Vector3.Distance(transform.position, desiredPosition);
        float rotationSpeed = speed / distance;

        // rotates the attached object toward the desired position
        transform.position = Vector3.RotateTowards(transform.position, desiredPosition, rotationSpeed * Time.deltaTime, 0f);
    }
}
