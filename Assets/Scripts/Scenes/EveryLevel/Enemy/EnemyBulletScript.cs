using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    // Made a separate script since this "type" of bullet has different physics.

    private GameObject player;
    private Rigidbody2D rb;
    public float force;

    private float timer;

    private float leftTime = 6;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        if(player != null)
        {
            Vector3 direction = player.transform.position - transform.position;
            rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

            float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rot + 90);

            if (PlayerPrefs.GetString("ReduceLag") == "True")
            {
                leftTime = leftTime - 2;
            }
            else
            {
                print("reduce lag no");
            }

            if (player == null)
            {
                Destroy(gameObject);
            }
        }
            
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if(timer > leftTime)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Spike")
        {
            Destroy(gameObject);
        }
    }
}
