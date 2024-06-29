using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Text coinText;

    [SerializeField] public int CoinsPerCoin;
    [SerializeField] public int MaxAmmo;
    [SerializeField] public string GunUpgrade;

    [SerializeField] public int CoinsPerCoinNextUpgradeNumber;
    [SerializeField] public int MaxAmmoNextUpgradeNumber;
    [SerializeField] public int GunUpgradeNextUpgradeNumber;

    [SerializeField] public int CoinsPerCoinCurrentPrice;
    [SerializeField] public int MaxAmmoCurrentPrice;
    [SerializeField] public int GunUpgradeCurrentPrice;

    [SerializeField] public int Coins;
    [SerializeField] public int Lives = 3;

    [SerializeField] public string NextGunUpgrade;

    [SerializeField] private PowerupCollisions powerupCollisions;
    [SerializeField] private ShootingScript shootingScript;

    [SerializeField] private GameObject pauseMenu;

    [SerializeField] private PlayerHit playerHit;

    [SerializeField] private GameObject music;
    [SerializeField] private GameObject endUI;
    [SerializeField] private GameObject shopUI;

    void Start()
    {
        CoinsPerCoinCurrentPrice = PlayerPrefs.GetInt("CPCCP");
        MaxAmmoCurrentPrice = PlayerPrefs.GetInt("MACP");
        GunUpgradeCurrentPrice = PlayerPrefs.GetInt("GUCP");
        MaxAmmo = PlayerPrefs.GetInt("MaxAmmo");
        CoinsPerCoin = PlayerPrefs.GetInt("CoinsPerCoin");
        GunUpgrade = PlayerPrefs.GetString("GunUpgrade");
        NextGunUpgrade = PlayerPrefs.GetString("NextGunUpgrade");
        CoinsPerCoinNextUpgradeNumber = PlayerPrefs.GetInt("CPCNUN");
        MaxAmmoNextUpgradeNumber = PlayerPrefs.GetInt("MANUN");
        GunUpgradeNextUpgradeNumber = PlayerPrefs.GetInt("GUNUN");
        Coins = PlayerPrefs.GetInt("Coins");
        playerHit = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHit>();
    }

    private void Update()
    {
        Lives = playerHit.lives;

        coinText.text = "Coins: " + Coins.ToString();

        powerupCollisions.CoinsPerCoin = CoinsPerCoin;
        shootingScript.MaxAmmo = MaxAmmo;

        if (GunUpgradeNextUpgradeNumber == 1)
        {
            GunUpgrade = "Laser Gun";
            NextGunUpgrade = "Shotgun";
        }
        if (GunUpgradeNextUpgradeNumber == 2)
        {
            GunUpgrade = "Shotgun";
            NextGunUpgrade = "Laser Gun V2";
        }
        if (GunUpgradeNextUpgradeNumber == 3)
        {
            GunUpgrade = "Laser Gun V2";
            NextGunUpgrade = "Shotgun V2";
        }
        if (GunUpgradeNextUpgradeNumber == 4)
        {
            GunUpgrade = "Shotgun V2";
            NextGunUpgrade = "Nothing";
        }

        if(Input.GetKeyDown(KeyCode.Escape) && endUI.activeInHierarchy == false)
        {
            if(shopUI.activeInHierarchy == false)
            {
                if (PlayerPrefs.GetString("GoBackToPauseThing") == "")
                {
                    PlayerPrefs.SetString("GoBackToPauseThing", "Menu");
                }
                if (pauseMenu.activeInHierarchy == false && Time.timeScale == 1)
                {
                    pauseMenu.SetActive(true);
                    Time.timeScale = 0;
                    music.SetActive(false);
                }
                else
                {
                    pauseMenu.SetActive(false);
                    Time.timeScale = 1;
                    music.SetActive(true);
                }
            }
        }
    }

    public void AddCoins(int Amount)
    {
        if (Amount <= CoinsPerCoin)
        {
            Coins = Coins + Amount;
            coinText.text = "Coins: " + Coins.ToString();
        }
        else
        {
            print("something went wrong!");
        }
    }

    public void SaveValues()
    {
        PlayerPrefs.SetInt("Coins", Coins);

        PlayerPrefs.SetInt("MaxAmmo", MaxAmmo);
        PlayerPrefs.SetInt("CoinsPerCoin", CoinsPerCoin);
        PlayerPrefs.SetString("GunUpgrade", GunUpgrade);

        PlayerPrefs.SetString("NextGunUpgrade", NextGunUpgrade);

        PlayerPrefs.SetInt("CPCNUN", CoinsPerCoinNextUpgradeNumber);
        PlayerPrefs.SetInt("MANUN", MaxAmmoNextUpgradeNumber);
        PlayerPrefs.SetInt("GUNUN", GunUpgradeNextUpgradeNumber);

        PlayerPrefs.SetInt("CPCCP", CoinsPerCoinCurrentPrice);
        PlayerPrefs.SetInt("MACP", MaxAmmoCurrentPrice);
        PlayerPrefs.SetInt("GUCP", GunUpgradeCurrentPrice);

        PlayerPrefs.Save();
    }
}
