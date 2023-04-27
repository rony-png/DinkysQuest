using UnityEngine;

public class LightSwing : MonoBehaviour
{
    public float amplitude = 1f;    // The amplitude of the swing
    public float frequency = 1f;    // The frequency of the swing
    public float phaseShift = 0f;   // The phase shift of the swing

    private Vector3 initialPosition; // The initial position of the light
    private float time = 0f;         // The current time

    private void Start()
    {
        // Store the initial position of the light
        initialPosition = transform.position;
    }

    private void Update()
    {
        // Increment the time variable
        time += Time.deltaTime;

        // Calculate the new position of the light based on the sine function
        float x = initialPosition.x + amplitude * Mathf.Sin(2 * Mathf.PI * frequency * time + phaseShift);
        float y = initialPosition.y;
        float z = initialPosition.z;

        // Update the position of the light
        transform.position = new Vector3(x, y, z);
    }
}
