using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestJump : MonoBehaviour
{
    public float DoubleJump;

    public float Jumps = 0;

    [SerializeField] private float jumpStrength;
    [SerializeField] private bool canJump;

    [SerializeField] private Transform groundChecker;
    [SerializeField] private LayerMask groundMask;

    private Rigidbody2D plrRigidbody;

    void Start()
    {
        plrRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        Debug.DrawRay(groundChecker.position, Vector2.down * 1.0f, Color.red);

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            GetComponent<AudioSource>().Play(0);
            canJump = true;
            plrRigidbody.velocity = Vector2.up * jumpStrength;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && DoubleJump >= 1 && Jumps >= 1)
        {
            plrRigidbody.velocity = Vector2.up * jumpStrength;
            Jumps += 1;
            GetComponent<AudioSource>().Play(0);
            //JumpsBeforeEnd = JumpsBeforeEnd + 1;
        }
        /*        else if (Input.GetKeyDown(KeyCode.Space) && DoubleJump >= 1 && JumpsBeforeEnd == 1 && doubleJumpAgain == true)
                {
                    plrRigidbody.velocity = Vector2.up * jumpStrength;
                    DoubleJump = DoubleJump - 1;
                    JumpsBeforeEnd = 0;
                    doubleJumpAgain = false;
                }*/
    }

    private bool IsGrounded()
    {
        RaycastHit2D hit;

        hit = Physics2D.Raycast(groundChecker.position, Vector2.down, 1.0f, groundMask);

        return hit;
    }
}
