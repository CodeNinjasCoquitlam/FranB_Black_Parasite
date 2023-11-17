using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Floats")]
    private float JumpHeight;
    private float Speed;
    [Header("Bools")]
    private bool isGrounded;
    [Header("Rigidbody 2D")]
    private Rigidbody2D Rigidbody2D;

    void Start()
    {
        JumpHeight = 7.5f;
        Speed = 9.65f;
        isGrounded = false;
        Rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }

    void Jump()
    {
        isGrounded = false;
        Rigidbody2D.AddForce(transform.up * JumpHeight, ForceMode2D.Impulse);
    }
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        Vector2 destination = new Vector2(horizontal, 0);
        transform.Translate(destination * Speed * Time.deltaTime);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        } 
    }
    void OnCollisionEnter2D(Collision2D other)
    {
       if(other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
}
