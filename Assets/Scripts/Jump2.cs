using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jump2 : MonoBehaviour
{
    // Thanks to firefly for script

   // public float JumpsBeforeEnd = 0;
    public float DoubleJump;

    public float Jumps = 0;

    [SerializeField] private float jumpStrength;
    [SerializeField] private bool canJump;

    [SerializeField] private Transform groundChecker;
    [SerializeField] private LayerMask groundMask;

    private Rigidbody2D plrRigidbody;

    [SerializeField] private GameObject iconImage = null;  // For powerup
    [SerializeField] private GameObject infoText = null;  // For powerup
    [SerializeField] private Sprite icon;                // For powerup

    void Start()
    {
        plrRigidbody = GetComponent<Rigidbody2D>();

        iconImage = GameObject.FindGameObjectWithTag("InfoImage");
        infoText = GameObject.FindGameObjectWithTag("InfoText");
    }

    void Update()
    {
        Debug.DrawRay(groundChecker.position, Vector2.down * 1.0f, Color.red);

        if(DoubleJump >= 0)
        {
            infoText.GetComponent<Text>().text = DoubleJump + " Double Jumps Remaining";
        }
        if(DoubleJump == 0)
        {
            infoText.SetActive(false);
            iconImage.SetActive(false);
        }
        if (IsGrounded()) {
            Jumps = 1;
        }

        if(Jumps == 2)
        {
            Jumps = 1;
            DoubleJump = DoubleJump - 1;
        }


        if (Jumps >= 2)
        {
            iconImage.SetActive(false);
            infoText.SetActive(false);
        }


        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            GetComponent<AudioSource>().Play(0);
            canJump = true;
            plrRigidbody.velocity = Vector2.up * jumpStrength;
        }
        else if(Input.GetKeyDown(KeyCode.Space) && DoubleJump >= 1 && Jumps >= 1)
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "DoubleJump")
        {
            DoubleJump = 3;
            infoText.GetComponent<Text>().text = DoubleJump + " Double Jumps Remaining";
            iconImage.GetComponent<Image>().sprite = icon;
            iconImage.SetActive(true);
            infoText.SetActive(true);
            Destroy(other.gameObject);
        }
    }
}
