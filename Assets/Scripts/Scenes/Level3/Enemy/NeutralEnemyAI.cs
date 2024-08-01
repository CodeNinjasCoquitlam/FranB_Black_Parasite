using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeutralEnemyAI : MonoBehaviour
{
    public GameObject player;

    public bool flip;

    public bool canJump;

    [SerializeField] private float speed;

    [SerializeField] private float gunDistance;

    [SerializeField] private GameObject enemies;
    private void Start()
    {
        canJump = true;

        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (player != null)
        {
            if (Vector2.Distance(player.transform.position, gameObject.transform.position) < gunDistance && Vector2.Distance(player.transform.position, gameObject.transform.position) > -gunDistance)
            {
                if (canJump)
                {
                    canJump = false;
                    Invoke("Jump", Random.Range(4, 6.5f));
                }

                Vector3 scale = transform.localScale;

                if (player.transform.position.x > transform.position.x)
                {
                    scale.x = Mathf.Abs(scale.x) * -1 * (flip ? -1 : 1);
                    transform.Translate(speed * Time.deltaTime * -1, 0, 0);
                }
                else
                {
                    scale.x = Mathf.Abs(scale.x) * (flip ? -1 : 1);
                    transform.Translate(speed * Time.deltaTime, 0, 0);
                }

                transform.localScale = scale;

                float distance = Vector2.Distance(transform.position, player.transform.position);
            }
        }
    }
    void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * 7;
        canJump = true;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Spike")
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "EscapePod")
        {
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
            enemies.SetActive(true);
        }
    }
}