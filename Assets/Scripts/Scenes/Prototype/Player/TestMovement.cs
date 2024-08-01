using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    [Header("Floats")]
    private float Speed;

    [Header("Rigidbody 2D")]
    private Rigidbody2D Rigidbody2D;

    [Header("SpriteRenderer")]

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        Time.timeScale = 1;
        Speed = 9.65f;
        Rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        Vector2 destination = new Vector2(horizontal, 0);

        transform.Translate(destination * Speed * Time.deltaTime);
        if (Input.GetKeyDown("a"))
        {
            spriteRenderer.flipX = true;
        }
        if (Input.GetKeyDown("d"))
        {
            spriteRenderer.flipX = false;
        }
        if (Input.GetKeyDown("h"))
        {
            spriteRenderer.flipX = true;
        }
        if (Input.GetKeyDown("k"))
        {
            spriteRenderer.flipX = false;
        }
        if (Input.GetKeyDown("left"))
        {
            spriteRenderer.flipX = true;
        }
        if (Input.GetKeyDown("right"))
        {
            spriteRenderer.flipX = false;
        }
    }
}
