using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebglCheck : MonoBehaviour
{
    public GameObject toDisable1;
    public GameObject toDisable2;
    public GameObject toDisable3;
    public GameObject toDisable4;
    void Start()
    {
        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            toDisable1.SetActive(false);
            toDisable2.SetActive(false);
            toDisable3.SetActive(false);
            toDisable4.SetActive(false);
        }
    }
}
