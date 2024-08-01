using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionToAccessSettingInfo : MonoBehaviour
{
    [SerializeField] private GameObject GGameObject;
    
    private void Start()
    {
        GGameObject.SetActive(true);
    }

    public void OK()
    {
        GGameObject.SetActive(false);
    }
}
