using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsManager : MonoBehaviour
{
    public Text coinText;

    private int Coins;

    void Start()
    {
        Coins = 0;
    }
    public void AddCoins(int Amount)
    {
        if(Amount < 5)
        {
            Coins = Coins + Amount;
            coinText.text = "Coins: " + Coins.ToString();
        }
        else
        {
            print("something went wrong!");
        }
    }
}
