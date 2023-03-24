using UnityEngine;

public class PerspectiveSwitch : MonoBehaviour
{
    private bool is2D = true;
    private Camera mainCamera;
    private float orthoSize = 5f;
    private Vector3 cameraPosition = new Vector3(1f, 4f, 1f);

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (is2D)
            {
                mainCamera.orthographic = false;
                mainCamera.transform.position = cameraPosition;
                mainCamera.fieldOfView = 60f;
                is2D = false;
            }
            else
            {
                mainCamera.orthographic = true;
                mainCamera.orthographicSize = orthoSize;
                mainCamera.transform.position = new Vector3(0f, 0f, -10f);
                is2D = true;
            }
        }
    }
}