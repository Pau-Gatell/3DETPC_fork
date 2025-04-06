using UnityEngine;

public class FloatUpDown : MonoBehaviour
{
    public float amplitude = 0.5f;  // The height of the floating movement
    public float frequency = 1f;    // The speed of the floating movement

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Calculate the new Y position
        float newY = startPosition.y + Mathf.Sin(Time.time * Mathf.PI * frequency) * amplitude;

        // Apply the new position to the object
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}