using UnityEngine;

public class CameraController1 : MonoBehaviour
{
    public float zoomSpeed = 0.5f; // The speed at which the camera zooms out
    public float targetSize = 10f; // The size at which the camera will stop zooming out
    public GameObject scriptedObject; // The object the player needs to collide with to trigger the camera zoom out

    private Camera cam; // Reference to the Camera component
    private bool isZoomingOut = false; // Flag to track if the camera is currently zooming out

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        if (isZoomingOut)
        {
            // Calculate the new size of the camera based on the zoom speed
            float newSize = cam.orthographicSize - (zoomSpeed * Time.deltaTime);

            // Clamp the new size to the target size so the camera stops zooming out when it reaches it
            newSize = Mathf.Clamp(newSize, targetSize, float.MaxValue);

            // Update the camera size
            cam.orthographicSize = newSize;

            // If the camera has reached the target size, stop zooming out
            if (newSize == targetSize)
            {
                isZoomingOut = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == scriptedObject)
        {
            isZoomingOut = true;
        }
    }
}
