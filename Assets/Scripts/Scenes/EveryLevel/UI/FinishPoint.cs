using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishPoint : MonoBehaviour
{
    [SerializeField] private GameObject winScreen;

    [SerializeField] private GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Invoke("Save", 1);
            winScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }

    void Save()
    {
        gameManager.SaveValues();
    }
}
