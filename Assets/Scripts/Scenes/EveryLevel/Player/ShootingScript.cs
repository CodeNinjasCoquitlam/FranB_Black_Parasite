using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShootingScript : MonoBehaviour
{
    [Header("Ints")]

    private int Shots;
    [SerializeField] public int MaxAmmo;
    private int bulletForce;

    [Header("Assets")]

    public GameObject originalBullet;
    public GameObject bigBullet;

    [Header("Directions")]

    public Vector2 BulletDirection;

    [Header("UI")]
    public Text maxAmmoText;
    public Text currentAmmoText;

    [Header("BulletSpawn")]
    public Transform BulletSpawn;

    [Header("Bools")]
    public bool HasGun;

    [Header("Scripts")]
    public GameManager gameManager;


    [SerializeField] private AudioSource shoot;
    void Start()
    {
        Shots = 0;
        MaxAmmo = 5;
        bulletForce = 20;

        if(SceneManager.GetActiveScene().name == "Arena")
        {
            Shots = 5;
        }
    }

    void Update()
    {
        KeyCode inputToShoot;

        if (PlayerPrefs.GetString("Shooting") == "")
        {
            PlayerPrefs.SetString("Shooting", "F");
            inputToShoot = KeyCode.F;
        }
        else
        {
            inputToShoot = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Shooting"));
        }

        currentAmmoText.text = Shots.ToString();
        maxAmmoText.text = MaxAmmo.ToString();
        if (Shots > MaxAmmo)
        {
            Shots = MaxAmmo;
            currentAmmoText.text = Shots.ToString();
        }
        if (Input.GetKeyDown(inputToShoot) && Shots > 0 && HasGun == true)
        {
            shoot.Play(0);
            if (gameManager.GunUpgrade == "Laser Gun")
            {
                Shots = Shots - 1;
                currentAmmoText.text = Shots.ToString();
                maxAmmoText.text = MaxAmmo.ToString();
                var bullet = Instantiate(originalBullet, BulletSpawn.position, transform.rotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(BulletDirection * bulletForce, ForceMode2D.Impulse);
            }
            if (gameManager.GunUpgrade == "Shotgun")
            {
                Shots = Shots - 1;
                currentAmmoText.text = Shots.ToString();
                maxAmmoText.text = MaxAmmo.ToString();
                var bullet1 = Instantiate(originalBullet, BulletSpawn.position, transform.rotation);
                var bullet2 = Instantiate(originalBullet, BulletSpawn.position, transform.rotation);
                var bullet3 = Instantiate(originalBullet, BulletSpawn.position, transform.rotation);
                bullet2.transform.position = new Vector2(bullet2.transform.position.x + 0.5f, bullet2.transform.position.y + 1);
                bullet3.transform.position = new Vector2(bullet3.transform.position.x + 0.5f, bullet3.transform.position.y - 1);
                Rigidbody2D rb1 = bullet1.GetComponent<Rigidbody2D>();
                Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
                Rigidbody2D rb3 = bullet3.GetComponent<Rigidbody2D>();
                rb1.AddForce(BulletDirection * bulletForce, ForceMode2D.Impulse);
                rb2.AddForce(BulletDirection * bulletForce, ForceMode2D.Impulse);
                rb3.AddForce(BulletDirection * bulletForce, ForceMode2D.Impulse);
            }
            if (gameManager.GunUpgrade == "Laser Gun V2")
            {
                Shots = Shots - 1;
                currentAmmoText.text = Shots.ToString();
                maxAmmoText.text = MaxAmmo.ToString();
                var bullet = Instantiate(bigBullet, BulletSpawn.position, transform.rotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(BulletDirection * bulletForce, ForceMode2D.Impulse);
            }
            if (gameManager.GunUpgrade == "Shotgun V2")
            {
                Shots = Shots - 1;
                currentAmmoText.text = Shots.ToString();
                maxAmmoText.text = MaxAmmo.ToString();
                var bullet1 = Instantiate(bigBullet, BulletSpawn.position, transform.rotation);
                var bullet2 = Instantiate(bigBullet, BulletSpawn.position, transform.rotation);
                var bullet3 = Instantiate(bigBullet, BulletSpawn.position, transform.rotation);
                bullet2.transform.position = new Vector2(bullet2.transform.position.x + 0.5f, bullet2.transform.position.y + 1);
                bullet3.transform.position = new Vector2(bullet3.transform.position.x + 0.5f, bullet3.transform.position.y - 1);
                Rigidbody2D rb1 = bullet1.GetComponent<Rigidbody2D>();
                Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
                Rigidbody2D rb3 = bullet3.GetComponent<Rigidbody2D>();
                rb1.AddForce(BulletDirection * bulletForce, ForceMode2D.Impulse);
                rb2.AddForce(BulletDirection * bulletForce, ForceMode2D.Impulse);
                rb3.AddForce(BulletDirection * bulletForce, ForceMode2D.Impulse);
            }
        }
    }

    public void AddShots(int HowMany)
    {
        if (HowMany > 10)
        {
            Shots = MaxAmmo;
            print(Shots);
            currentAmmoText.text = Shots.ToString();
        }
        else
        {
            Shots = Shots + HowMany;
            currentAmmoText.text = Shots.ToString();
        }
    }
}
