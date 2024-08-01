using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateBreak : MonoBehaviour
{
    // Thanks to Sykoo from the unity forums for the script!
    public bool grounded;

    public float timeInAir = 1;

    [SerializeField] private GameObject[] possibleObjects;

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.layer == 3)
        {
            grounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        grounded = false;
    }

    void Update()
    {
        //Here we decrease the time in air from 5
        //Grounded is used by Rigidbody controller
        if (!grounded)
            timeInAir -= 1 * Time.deltaTime;


        //Making the crate die when it reaches 0
        if (grounded && timeInAir <= 0)
        {
            int RNG = Random.Range(0, possibleObjects.Length);

            Quaternion q = new Quaternion(0, 0, 0, 0);

            Instantiate(possibleObjects[RNG], transform.position, q);

            Destroy(gameObject);
        }
        else
        {
            //Increase the time in air to reach 5 each time we're on ground
            if (grounded && timeInAir < 1 && timeInAir > 0)
                timeInAir = 1;
        }
    }
    /*private Vector2 previousPosition;

    private Vector2 currentPosition;

    private int breakDistance;

    void Start()
    {
        previousPosition = new Vector2(transform.position.x, transform.position.y);
        breakDistance = 5;
    }

    void Update()
    {
        currentPosition = new Vector2(transform.position.x, transform.position.y);

        if (currentPosition.y < previousPosition.y)
        {
            if (currentPosition.y < -breakDistance)
            {
                print("broken lol");
            }
        }
    }*/
}
