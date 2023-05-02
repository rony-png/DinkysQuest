using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSpawning : MonoBehaviour
{
    public GameObject lightPrefab;
    public float spawnInterval;
    public float spawnRadius;
    private float timeSinceLastSpawn = 0;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

    }
}
