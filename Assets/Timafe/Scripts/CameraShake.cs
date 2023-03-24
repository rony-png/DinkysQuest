using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Transform player; // Player object
    public Transform objectToCheck; // Object to check distance from
    public float maxDistance; // Max distance to start shaking
    public float shakeIntensity; // Intensity of the camera shake
    public float shakeSpeed; // Speed of the camera shake

    private float distance; // Distance between player and object
    private Vector3 originalPosition; // Original position of the camera
    private float shakeTimer; // Timer for the camera shake

    void Start()
    {
        originalPosition = transform.localPosition;
    }

    void Update()
    {
        distance = Vector3.Distance(player.position, objectToCheck.position);

        if (distance <= maxDistance)
        {
            shakeTimer += Time.deltaTime * shakeSpeed;

            Vector3 shakeOffset = new Vector3(Mathf.PerlinNoise(shakeTimer, 0) - 0.5f,
                                              Mathf.PerlinNoise(0, shakeTimer) - 0.5f,
                                              0) * shakeIntensity;

            transform.localPosition = originalPosition + shakeOffset;
        }
        else
        {
            transform.localPosition = originalPosition;
            shakeTimer = 0;
        }
    }
}
