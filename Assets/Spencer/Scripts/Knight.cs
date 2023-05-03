using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    public GameObject knight;
    public float speed;
    public float hori;
    public float vert;
    // Start is called before the first frame update
    void Start()
    {
        vert = Input.GetAxis("Vertical");
        hori = Input.GetAxis("Horizontal");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
