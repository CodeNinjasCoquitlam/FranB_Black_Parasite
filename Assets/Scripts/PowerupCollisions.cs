using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerupCollisions : MonoBehaviour
{
    [Header("GameObjects")]

    private GameObject player;

    [Header("Player Components")]

    private SpriteRenderer playerSprite;
    private ShootingScript ShootScript;

    [Header("Sprites")]

    public Sprite playerWithHands;
    public Sprite playerWithGun;

    [Header("Bools")]

    [SerializeField] private bool Hands;
    [SerializeField] private bool Gun;

    [Header("Ints")]
    private int AmmoPerBox;
    [SerializeField] public int CoinsPerCoin;

    [Header("UI")]
    public GameObject AmmoUI;

    [Header("Scripts")]
    public GameManager gameManager;

    void Start()
    {
        AmmoPerBox = 5;
        CoinsPerCoin = 1;
        player = gameObject;
        ShootScript = player.GetComponent<ShootingScript>();
        playerSprite = player.GetComponent<SpriteRenderer>();
        if (Hands == true)
        {
            playerSprite.sprite = playerWithHands;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Hands" && !Hands)
        {
            Hands = true;
            Destroy(other.gameObject);
            playerSprite.sprite = playerWithHands;
        }
        else
        {
            if(other.gameObject.tag == "LaserGun" && Hands && !Gun)
            {
                ShootScript.HasGun = true;
                AmmoUI.SetActive(true);
                Gun = true;
                Destroy(other.gameObject);
                playerSprite.sprite = playerWithGun;
            }
            else
            {
                if(other.gameObject.tag == "AmmoBox" && Hands)
                {
                    Destroy(other.gameObject);
                    ShootScript.AddShots(AmmoPerBox);
                }
                else
                {
                    if(other.gameObject.tag == "Coin") // You dont need hands cuz logic doesnt exist
                    {
                        Destroy(other.gameObject);
                        gameManager.AddCoins(CoinsPerCoin);
                    }
                }
            }
        }
    }
}
