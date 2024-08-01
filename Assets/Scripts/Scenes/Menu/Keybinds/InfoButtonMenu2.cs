using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoButtonMenu2 : MonoBehaviour
{
    public void Click(GameObject gameObject)
    {
        if(gameObject.activeInHierarchy == true)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}
