using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBGMusic : MonoBehaviour
{
    public static MenuBGMusic instance;

    void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
