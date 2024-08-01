using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Floats")]
    private float Speed;

    [Header("Rigidbody 2D")]
    private Rigidbody2D Rigidbody2D;

    [Header("Scripts")]
    private ShootingScript shootingScript;

    [Header("SpriteRenderer")]

    private SpriteRenderer spriteRenderer;

    [Header("BulletSpawns")]
    public GameObject BulletSpawn1;
    public GameObject BulletSpawn2;

    private Transform BulletSpawn1Transform;
    private Transform BulletSpawn2Transform;

    void Start()
    {
        print(PlayerPrefs.GetString("GunUpgrade"));
        Speed = 9.65f;
        Rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        shootingScript = gameObject.GetComponent<ShootingScript>();
        BulletSpawn1Transform = BulletSpawn1.transform;
        BulletSpawn2Transform = BulletSpawn2.transform;
    }
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        Vector2 destination = new Vector2(horizontal, 0);

        transform.Translate(destination * Speed * Time.deltaTime);
        if (Input.GetKeyDown("a"))
        {
            spriteRenderer.flipX = true;
            shootingScript.BulletDirection = Vector2.left;
            shootingScript.BulletSpawn = BulletSpawn2Transform;
        }
        if (Input.GetKeyDown("d"))
        {
            spriteRenderer.flipX = false;
            shootingScript.BulletDirection = Vector2.right;
            shootingScript.BulletSpawn = BulletSpawn1Transform;
        }
        if (Input.GetKeyDown("h"))
        {
            spriteRenderer.flipX = true;
            shootingScript.BulletDirection = Vector2.left;
            shootingScript.BulletSpawn = BulletSpawn2Transform;
        }
        if (Input.GetKeyDown("k"))
        {
            spriteRenderer.flipX = false;
            shootingScript.BulletDirection = Vector2.right;
            shootingScript.BulletSpawn = BulletSpawn1Transform;
        }
        if (Input.GetKeyDown("left"))
        {
            spriteRenderer.flipX = true;
            shootingScript.BulletDirection = Vector2.left;
            shootingScript.BulletSpawn = BulletSpawn2Transform;
        }
        if (Input.GetKeyDown("right"))
        {
            spriteRenderer.flipX = false;
            shootingScript.BulletDirection = Vector2.right;
            shootingScript.BulletSpawn = BulletSpawn1Transform;
        }
    }
}
