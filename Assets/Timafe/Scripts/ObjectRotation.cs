using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    public float amplitude = 10f;   // The amplitude of the rotation
    public float frequency = 1f;    // The frequency of the rotation
    public float phaseShift = 0f;   // The phase shift of the rotation

    private Quaternion initialRotation; // The initial rotation of the object
    private float time = 0f;            // The current time

    private void Start()
    {
        // Store the initial rotation of the object
        initialRotation = transform.rotation;
    }

    private void Update()
    {
        // Increment the time variable
        time += Time.deltaTime;

        // Calculate the new rotation of the object based on the sine function
        float angle = amplitude * Mathf.Sin(2 * Mathf.PI * frequency * time + phaseShift);
        Quaternion rotation = initialRotation * Quaternion.Euler(0f, 0f, angle);

        // Update the rotation of the object
        transform.rotation = rotation;
    }
}
