using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    // If you are reading this you are looking at scripts and figuring out how it works this is literally Sphagetti code so ill explain it :D

    // Variables
    [SerializeField] private Button backButton;
    [SerializeField] private Button coinsPerCoinBuy;
    [SerializeField] private Button maxAmmoBuy;
    [SerializeField] private Button gunUpgradeBuy;

    [SerializeField] private Text coinsPerCoinBuyText;
    [SerializeField] private Text maxAmmoBuyText;
    [SerializeField] private Text gunUpgradeBuyText;

    [SerializeField] private Text coinsPerCoinUpgradeText;
    [SerializeField] private Text maxAmmoUpgradeText;
    [SerializeField] private Text gunUpgradeUpgradeText;

    [SerializeField] private Text coinsPerCoinUpgradeInfoText;
    [SerializeField] private Text maxAmmoUpgradeInfoText;
    [SerializeField] private Text gunUpgradeUpgradeInfoText;

    [SerializeField] private int priceCoinsPerCoin;
    [SerializeField] private int priceMaxAmmo;
    [SerializeField] private int priceGunUpgrade;

    [SerializeField] GameManager gameManager;

    private void Start()
    {
        if(PlayerPrefs.GetInt("CPCCP") == 0 || PlayerPrefs.GetInt("MACP") == 0 || PlayerPrefs.GetInt("GUCP") == 0)
        {
            priceCoinsPerCoin = 73;
            priceGunUpgrade = 200;
            priceMaxAmmo = 100;
        }
        else
        {
            priceCoinsPerCoin = PlayerPrefs.GetInt("CPCCP");
            priceMaxAmmo = PlayerPrefs.GetInt("MACP");
            priceGunUpgrade = PlayerPrefs.GetInt("GUCP");
        }
    }

    private void Awake()
    {
        coinsPerCoinBuy.onClick.AddListener(() => { // If coin upgrade button is clicked
            if (gameManager.Coins >= priceCoinsPerCoin) // If the player's money is more than the price
            {
                gameManager.CoinsPerCoin = gameManager.CoinsPerCoin + 1; // Adds 1 to the upgrade the player bought
                gameManager.CoinsPerCoinNextUpgradeNumber = gameManager.CoinsPerCoinNextUpgradeNumber + 1; // Adds 1 to the upgrade number which is the item's upgrade number that the player bought
                gameManager.Coins = gameManager.Coins - priceCoinsPerCoin; // Removes the amount of coins that is the price for the item the player bought
                priceCoinsPerCoin = priceCoinsPerCoin + priceCoinsPerCoin / 2; // Makes the price the price + price / 2
                gameManager.CoinsPerCoinCurrentPrice = priceCoinsPerCoin;
                gameManager.MaxAmmoCurrentPrice = priceMaxAmmo;
                gameManager.GunUpgradeCurrentPrice = priceGunUpgrade;
            }
        });
        gunUpgradeBuy.onClick.AddListener(() => { // If gun upgrade button is clicked
            if (gameManager.Coins >= priceGunUpgrade) // If the player's money is more than the price
            {
                gameManager.GunUpgradeNextUpgradeNumber = gameManager.GunUpgradeNextUpgradeNumber + 1; // Adds 1 to the upgrade number which is the item's upgrade number that the player bought
                gameManager.Coins = gameManager.Coins - priceGunUpgrade; // Removes the amount of coins that is the price for the item the player bought
                priceGunUpgrade = priceGunUpgrade * 3 / 2; // Multiplies the price then divides it by 2 
                gameManager.CoinsPerCoinCurrentPrice = priceCoinsPerCoin;
                gameManager.MaxAmmoCurrentPrice = priceMaxAmmo;
                gameManager.GunUpgradeCurrentPrice = priceGunUpgrade;
            }
        });
        maxAmmoBuy.onClick.AddListener(() => { // If max ammo upgrade button is clicked
            if (gameManager.Coins >= priceMaxAmmo) // If the player's money is more than the price
            {
                gameManager.MaxAmmo = gameManager.MaxAmmo + 1; // Adds 1 to the upgrade the player bought
                gameManager.MaxAmmoNextUpgradeNumber = gameManager.MaxAmmoNextUpgradeNumber + 1; // Adds 1 to the upgrade number which is the item's upgrade number that the player bought
                gameManager.Coins = gameManager.Coins - priceMaxAmmo; // Removes the amount of coins that is the price for the item the player bought
                priceMaxAmmo = priceMaxAmmo + priceMaxAmmo / 2; // Makes the price the price + price / 2
                gameManager.CoinsPerCoinCurrentPrice = priceCoinsPerCoin;
                gameManager.MaxAmmoCurrentPrice = priceMaxAmmo;
                gameManager.GunUpgradeCurrentPrice = priceGunUpgrade;
            }
        });
        backButton.onClick.AddListener(() => { // The back button to go back to the REAL game
            gameObject.SetActive(false); // Goes back to the REAL game
            Time.timeScale = 1;
        });
    }

    private void Update()
    {
        // Make fun of me all you want I use upgrade AND SO?
        // If you make fun of me press alt + f4 to own this game(real)

        maxAmmoBuyText.GetComponent<Text>().text = "Buy 4 $" + priceMaxAmmo.ToString(); // Makes the Buy Button's text "Buy 4 $theprice
        coinsPerCoinBuyText.GetComponent<Text>().text = "Buy 4 $" + priceCoinsPerCoin.ToString(); // Makes the Buy Button's text "Buy 4 $theprice
        gunUpgradeBuyText.GetComponent<Text>().text = "Buy 4 $" + priceGunUpgrade.ToString(); // Makes the Buy Button's text "Buy 4 $theprice

        coinsPerCoinUpgradeText.GetComponent<Text>().text = "Upgrade: " + gameManager.CoinsPerCoinNextUpgradeNumber.ToString();  // Makes the upgrade number's text the next upgrade's number
        maxAmmoUpgradeText.GetComponent<Text>().text = "Upgrade: " + gameManager.MaxAmmoNextUpgradeNumber.ToString(); // Makes the upgrade number's text the next upgrade's number
        gunUpgradeUpgradeText.GetComponent<Text>().text = "Upgrade: " + gameManager.GunUpgradeNextUpgradeNumber.ToString(); // Makes the upgrade number's text the next upgrade's number

        var ncoinv = gameManager.CoinsPerCoin + 1; // Next Coin Value
        var nmaxAmmov = gameManager.MaxAmmo + 1; // Next Max Ammo Value

        coinsPerCoinUpgradeInfoText.GetComponent<Text>().text = "Current Upgrade: " + gameManager.CoinsPerCoin.ToString() + " Coin Per Coin. Next Upgrade: " + ncoinv + " Coins per coin."; // Changes the text
        maxAmmoUpgradeInfoText.GetComponent<Text>().text = "Current Upgrade: " + gameManager.MaxAmmo.ToString() + " Is Max Ammo. Next Upgrade: " + nmaxAmmov + " Is Max Ammo."; // Changes the text
        gunUpgradeUpgradeInfoText.GetComponent<Text>().text = "Current Upgrade: " + gameManager.GunUpgrade.ToString() + ". Next Upgrade: " + gameManager.NextGunUpgrade.ToString(); // Changes the text

        if (priceGunUpgrade >= 1250) // If the price of this upgrade is more than 1250
        {
            priceGunUpgrade = Random.Range(650, 1250); // Make the price be randomly picked which could be from 650 to 1250
        }
        if (priceCoinsPerCoin >= 1000) // If the price of this upgrade is more than 1000 
        {
            priceCoinsPerCoin = Random.Range(250, 1000); // Make the price be randomly picked which could be from 250 to 1000
        }
        if (priceMaxAmmo >= 1000) // If the price of this upgrade is more than 1000
        {
            priceMaxAmmo = Random.Range(250, 1000); // Make the price be randomly picked which could be from 250 to 1000
        }
        if (gameManager.GunUpgradeNextUpgradeNumber >= 4) // If the gun's upgrade number is more than 4
        {
            gunUpgradeBuyText.text = "MAX UPGRADE";
            gunUpgradeBuy.GetComponent<Button>().enabled = false;
        }
    }
    // Yeah hoped you understood everything I wrote this cuz why not?
}
