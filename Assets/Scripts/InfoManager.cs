using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoManager : MonoBehaviour
{
    [SerializeField] private Text infoText;

    [SerializeField] private GameObject infoGameObject;

    public void ChangeInfo(string theInfo)
    {
        infoText.text = theInfo;
        infoGameObject.SetActive(true);
    }

    public void OK()
    {
        infoGameObject.SetActive(false);
    }
}
