using System.Collections;
using UnityEngine;


public class CameraZoomTrigger : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _zoomAmount = 2f;
    [SerializeField] private float _maxZoomSize = 10f;

    private bool _hasCollided = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!_hasCollided && other.CompareTag("Player"))
        {
            _hasCollided = true;
            StartCoroutine(ZoomOut());
        }
    }

    private IEnumerator ZoomOut()
    {
        float originalSize = _camera.orthographicSize;
        float targetSize = Mathf.Min(_maxZoomSize, originalSize * _zoomAmount);

        while (_camera.orthographicSize < targetSize)
        {
            _camera.orthographicSize += Time.deltaTime * _zoomAmount;
            yield return null;
        }

        _camera.orthographicSize = targetSize;
    }
}
