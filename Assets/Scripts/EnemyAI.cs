using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject enemyBullet;

    public GameObject player;

    public GameObject bulletSpawn;

    public bool flip;

    public bool canJump;

    [SerializeField] private float tierEnemy;

    [SerializeField] private float speed;

    [SerializeField] private float timer;

    [SerializeField] private float timerToReload;

    [SerializeField] private float distanceToShoot;

    private void Start()
    {
        canJump = true;
        if (tierEnemy == 0)
        {
            speed = 3.5f;
            timerToReload = 7;
            distanceToShoot = 10;
        }

        if (tierEnemy == 1)
        {
            speed = 3.986f;
            timerToReload = 6.5f;
            distanceToShoot = 11;
        }

        player = GameObject.FindGameObjectWithTag("Player");

        if (PlayerPrefs.GetString("ReduceLag") == "True")
        {
            timerToReload = timerToReload + 4;
        }
        else
        {
            print("reduce lag no");
        }
    }

    private void Update()
    {
        if (player != null)
        {
            if (Vector2.Distance(player.transform.position, gameObject.transform.position) < distanceToShoot && Vector2.Distance(player.transform.position, gameObject.transform.position) > -distanceToShoot)
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
                    transform.Translate(speed * Time.deltaTime, 0, 0);
                }
                else
                {
                    scale.x = Mathf.Abs(scale.x) * (flip ? -1 : 1);
                    transform.Translate(speed * Time.deltaTime * -1, 0, 0);
                }

                transform.localScale = scale;

                timer += Time.deltaTime;

                float distance = Vector2.Distance(transform.position, player.transform.position);

                if (distance < distanceToShoot)
                {
                    timer += Time.deltaTime;
                    if (timer > timerToReload)
                    {
                        timer = 0;
                        Invoke("ShootBullet", 3);
                    }
                }
            }
        }
    }
    private void ShootBullet()
    {
        Instantiate(enemyBullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
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
}