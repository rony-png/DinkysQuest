using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    Rigidbody2D rb2D;
    public float hori;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        hori = Input.GetAxis("Horizontal");
        rb2D = GetComponent<Rigidbody2D>();
        anim.SetFloat("Hori", hori);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D wall = Physics2D.Raycast(transform.position, Vector2.right);
        transform.Translate(Vector3.forward * Time.deltaTime * 5);
    }
}
