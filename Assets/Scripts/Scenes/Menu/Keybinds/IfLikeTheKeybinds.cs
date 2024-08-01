using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfLikeTheKeybinds : MonoBehaviour
{
    void Start()
    {
        if(PlayerPrefs.GetString("Shooting") == "")
        {
            PlayerPrefs.SetString("Shooting", "F");
        }
        if (PlayerPrefs.GetString("Interact") == "")
        {
            PlayerPrefs.SetString("Interact", "E");
        }
    }
}
