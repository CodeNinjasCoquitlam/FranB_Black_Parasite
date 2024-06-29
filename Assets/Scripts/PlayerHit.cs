using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerHit : MonoBehaviour
{
    public int lives;

    private bool dead = false;

    [SerializeField] private float invincibleTime;
    [SerializeField] private bool invincible;
    [SerializeField] private bool invincible2;

    [SerializeField] private Animator plranimator;

    [SerializeField] private string invincibleAnimToPlay;

    [SerializeField] private Text livesText;

    [SerializeField] private GameObject deadUI;

    [SerializeField] private float invincibilityTimer;

    [SerializeField] private GameObject iconImage = null;  // For powerup
    [SerializeField] private GameObject infoText = null;  // For powerup
    [SerializeField] private Sprite icon;                // For powerup

    

    void Start()
    {
        Invoke("SetLives", 1);

        iconImage = GameObject.FindGameObjectWithTag("InfoImage");
        infoText = GameObject.FindGameObjectWithTag("InfoText");

        Invoke("Off", 1.5f);
    }

    void SetLives()
    {
        lives = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().Lives;
    }

    private void Off()
    {
        iconImage.SetActive(false);
        iconImage.GetComponent<Image>().color = new Color(255, 255, 255);
        infoText.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "EnemyBullet" && invincible == false)
        {
            invincibleTime = 4;
            plranimator.enabled = true;
            plranimator.Play(invincibleAnimToPlay, 0, 0.0f);
            Destroy(other.gameObject);
            lives = lives - 1;
            invincible = true;
            iconImage.SetActive(true);
            infoText.SetActive(true);
            iconImage.GetComponent<Image>().sprite = icon;
            infoText.GetComponent<Text>().text = "Time left until invincibility ends: " + invincibilityTimer;
        }
        if (other.gameObject.tag == "Invincibility")
        {
            Destroy(other.gameObject);
            invincibleTime = 10;
            plranimator.enabled = true;
            plranimator.Play(invincibleAnimToPlay, 0, 0.0f);
            invincible = true;
            iconImage.SetActive(true);
            infoText.SetActive(true);
            iconImage.GetComponent<Image>().sprite = icon;
            infoText.GetComponent<Text>().text = "Time left until invincibility ends: " + invincibilityTimer;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Spike" && invincible == false)
        {
            invincibleTime = 4;
            plranimator.enabled = true;
            plranimator.Play(invincibleAnimToPlay, 0, 0.0f);
            lives = lives - 1;
            invincible = true;
            iconImage.SetActive(true);
            infoText.SetActive(true);
            iconImage.GetComponent<Image>().sprite = icon;
            infoText.GetComponent<Text>().text = "Time left until invincibility ends: " + invincibilityTimer;
        }
        if (other.gameObject.tag == "Enemy" && invincible == false && invincible2 == false)
        {
            invincible2 = true;
            gameObject.GetComponent<Movement>().enabled = false;
            iconImage.SetActive(true);
            infoText.SetActive(true);
            iconImage.GetComponent<Image>().sprite = icon;
            infoText.GetComponent<Text>().text = "You are currently stunned and cant move";
            Invoke("StunnedOver", 3);
        }
        if (other.gameObject.tag == "Wires" && invincible == false)
        {
            invincibleTime = 4;
            plranimator.enabled = true;
            plranimator.Play(invincibleAnimToPlay, 0, 0.0f);
            lives = lives - 1;
            invincible = true;
            iconImage.SetActive(true);
            infoText.SetActive(true);
            iconImage.GetComponent<Image>().sprite = icon;
            infoText.GetComponent<Text>().text = "Time left until invincibility ends: " + invincibilityTimer;
        }
    }
    private void Update()
    {
        livesText.text = "Lives: " + lives;

        if(lives <= 0)
        {
            if(dead == false)
            {
                dead = true;
                Destroy(gameObject);
                deadUI.SetActive(true);
            }
        }

        if(invincible == true)
        {
            infoText.GetComponent<Text>().text = "Time left until invincibility ends: " + (int)invincibleTime;

            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

            Color tmp = spriteRenderer.color;

            tmp.a = 255f;

            invincibleTime -= Time.deltaTime;

            if (invincibleTime <= invincibilityTimer)
            {
                spriteRenderer.color = tmp;
                plranimator.enabled = false;
                invincible = false;
                invincibleTime = 0;
                invincibilityTimer = 0;
                iconImage.SetActive(false);
                infoText.SetActive(false);
            }
        }
    }

    void StunnedOver()
    {
        iconImage.SetActive(false);
        infoText.SetActive(false);
        gameObject.GetComponent<Movement>().enabled = true;
        Invoke("CanBeStunned", 3);
    }

    void CanBeStunned()
    {
        invincible2 = false;
    }
}
