using UnityEngine;

public class FlickerEffect : MonoBehaviour
{
    public float minPositionOffset = -0.1f; // The minimum position offset
    public float maxPositionOffset = 0.1f; // The maximum position offset
    public float minFlickerTime = 0.05f; // The minimum time between flickers, in seconds
    public float maxFlickerTime = 0.5f; // The maximum time between flickers, in seconds

    private Vector2 startPosition;
    private float elapsedTime = 0f;
    private float flickerTime;

    private void Start()
    {
        startPosition = transform.position;
        flickerTime = Random.Range(minFlickerTime, maxFlickerTime);
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= flickerTime)
        {
            transform.position = new Vector2(
                startPosition.x + Random.Range(minPositionOffset, maxPositionOffset),
                startPosition.y + Random.Range(minPositionOffset, maxPositionOffset)
            );

            flickerTime = Random.Range(minFlickerTime, maxFlickerTime);
            elapsedTime = 0f;
        }
    }
}
