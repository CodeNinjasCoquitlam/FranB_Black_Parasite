using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class KeybindManager : MonoBehaviour
{

    private Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();

    public Text Shooting, Interact, OpenShop, Button;

    public Button ShootingB, InteractB, OpenShopB, ButtonB;

    public GameObject specificKeybindsInteract;

    public Toggle advancedToggleInteract;

    public GameObject currentKey;

    private Color32 normal = new Color(0, 139, 241, 255);
    private Color32 selected = new Color(255, 166, 0, 255);

    void Start()
    {
        keys.Add("Shooting", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("F", "F")));
        keys.Add("Interact", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("E", "E")));
        keys.Add("OpenShop", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("E", "E")));
        keys.Add("Button", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("E", "E")));

        Shooting.text = keys["Shooting"].ToString();
        Interact.text = keys["Interact"].ToString();
        OpenShop.text = keys["OpenShop"].ToString();
        Button.text = keys["Button"].ToString();

        Shooting.text = PlayerPrefs.GetString("Shooting");
        Interact.text = PlayerPrefs.GetString("Interact");
        OpenShop.text = PlayerPrefs.GetString("OpenShop");
        Button.text = PlayerPrefs.GetString("Button");
        currentKey = null;

        if (PlayerPrefs.GetString("InteractAdvanced") == "True")
        {
            advancedToggleInteract.isOn = true;
        }
        else
        {
            advancedToggleInteract.isOn = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(keys["Shooting"]))
        {
            print("shot");
        }
        if (Input.GetKeyDown(keys["Interact"]))
        {
            print("interacted(real)");
        }
        if (Input.GetKeyDown(keys["OpenShop"]))
        {
            print("OpenedShop");
        }
        if (Input.GetKeyDown(keys["Button"]))
        {
            print("Button has been pressed button");
        }
        if (currentKey == null)
        {
            PlayerPrefs.SetString("Shooting", Shooting.text);
            PlayerPrefs.SetString("Interact", Interact.text);
            PlayerPrefs.SetString("OpenShop", OpenShop.text);
            PlayerPrefs.SetString("Button", Button.text);
        }

        specificKeybindsInteract.SetActive(advancedToggleInteract.isOn);
        PlayerPrefs.SetString("InteractAdvanced", advancedToggleInteract.isOn.ToString());
    }

    void OnGUI()
    {
        if (currentKey != null)
        {
            Event e = Event.current;

            if (e.isKey)
            {
                keys[currentKey.name] = e.keyCode;
                currentKey.transform.GetChild(0).GetComponent<Text>().text = e.keyCode.ToString();
                currentKey.GetComponent<Image>().color = normal;
                currentKey = null;
            }
        }
    }

    public void ChangeKey(GameObject clicked)
    {
        if (currentKey != null)
        {
            currentKey.GetComponent<Image>().color = normal;
        }

        currentKey = clicked;
        currentKey.GetComponent<Image>().color = selected;
    }

    public void ResetChosenKey()
    {
        if (currentKey != null)
        {
            keys.Remove(currentKey.name);

            if (currentKey.name == "Shooting")
            {
                keys.Add(currentKey.name, KeyCode.F);
                PlayerPrefs.SetString(currentKey.name, "F");
                currentKey.GetComponent<Image>().color = normal;
                currentKey.transform.GetChild(0).GetComponent<Text>().text = "F";
                currentKey = null;
            }
            if (currentKey.name == "Interact")
            {
                keys.Add(currentKey.name, KeyCode.E);
                PlayerPrefs.SetString(currentKey.name, "E");
                currentKey.GetComponent<Image>().color = normal;
                currentKey.transform.GetChild(0).GetComponent<Text>().text = "E";
                currentKey = null;
            }
            if (currentKey.name == "OpenShop")
            {
                keys.Add(currentKey.name, KeyCode.E);
                PlayerPrefs.SetString(currentKey.name, "E");
                currentKey.GetComponent<Image>().color = normal;
                currentKey.transform.GetChild(0).GetComponent<Text>().text = "E";
                currentKey = null;
            }
            if (currentKey.name == "Button")
            {
                keys.Add(currentKey.name, KeyCode.E);
                PlayerPrefs.SetString(currentKey.name, "E");
                currentKey.GetComponent<Image>().color = normal;
                currentKey.transform.GetChild(0).GetComponent<Text>().text = "E";
                currentKey = null;
            }
        }
    }
    public void ResetAllKeys()
    {

        keys.Clear();
        // Shooting
        keys.Add("Shooting", KeyCode.F);
        ShootingB.GetComponent<Image>().color = normal;
        Shooting.GetComponent<Text>().text = "F";
        // Interact
        keys.Add("Interact", KeyCode.E);
        InteractB.GetComponent<Image>().color = normal;
        Interact.GetComponent<Text>().text = "E";
        // Open Shop
        keys.Add("OpenShop", KeyCode.E);
        OpenShopB.GetComponent<Image>().color = normal;
        OpenShop.GetComponent<Text>().text = "E";
        // Button
        keys.Add("Button", KeyCode.E);
        ButtonB.GetComponent<Image>().color = normal;
        Button.GetComponent<Text>().text = "E";
    }

    public void SaveKeys()
    {
        foreach (var key in keys)
        {
            PlayerPrefs.SetString(key.Key, key.Value.ToString());
        }

        PlayerPrefs.Save();
    }
}