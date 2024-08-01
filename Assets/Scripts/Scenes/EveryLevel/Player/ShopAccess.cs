using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopAccess : MonoBehaviour
{
    private bool CanGetIn;

    [SerializeField] private GameObject shopUI;
    [SerializeField] private GameObject interactUI;

    [SerializeField] private Text keyToInteract;

    void Start()
    {
        CanGetIn = false;
    }

    void Update()
    {
        KeyCode inputToInteract;

        if(PlayerPrefs.GetString("InteractAdvanced") == "True")
        {
            inputToInteract = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("OpenShop"));
        }
        else
        {
            if (PlayerPrefs.GetString("Interact") == "")
            {
                PlayerPrefs.SetString("Interact", "E");
                inputToInteract = KeyCode.E;
            }
            else
            {
                inputToInteract = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Interact"));
            }
        }

        if (CanGetIn == true)
        {
            if(Input.GetKeyDown(inputToInteract))
            {
                shopUI.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Shop")
        {
            CanGetIn = true;
            interactUI.SetActive(true);
            if(PlayerPrefs.GetString("InteractAdvanced") == "True")
            {
                keyToInteract.text = PlayerPrefs.GetString("OpenShop");
            }
            else
            {
                keyToInteract.text = PlayerPrefs.GetString("Interact");
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Shop")
        {
            CanGetIn = false;
            interactUI.SetActive(false);
        }
    }
}
