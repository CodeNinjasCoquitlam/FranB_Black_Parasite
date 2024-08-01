using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpikesGoDown : MonoBehaviour
{
    [SerializeField] private GameObject spikes;
    [SerializeField] private GameObject interactUI;

    [SerializeField] private Text keyText;

    private bool can = false;

    private Vector3 start;

    void Start()
    {
        start = spikes.transform.position;
        can = false;
    }
    
    void Update()
    {
        KeyCode inputToInteract;

        if (PlayerPrefs.GetString("InteractAdvanced") == "True")
        {
            inputToInteract = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Button"));
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

        if (Input.GetKeyDown(inputToInteract) && can == true && spikes.transform.position == start)
        {
            can = false;
            Vector2 destination = new Vector2(0, -25);

            spikes.transform.localScale = new Vector3(2.611761f, 4f, 1);
            spikes.transform.position = new Vector3(start.x, start.y - 1f, start.z);

            Invoke("Up", 3);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            interactUI.SetActive(true);

            can = true;

            if (PlayerPrefs.GetString("InteractAdvanced") == "True")
            {
                keyText.text = PlayerPrefs.GetString("Button");
            }
            else
            {
                keyText.text = PlayerPrefs.GetString("Interact");
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            interactUI.SetActive(false);
            can = false;
        }
    }

    void Up()
    {
        can = true;
        spikes.transform.localScale = new Vector3(2.611761f, 2.393635f, 1);
        spikes.transform.position = start;
    }
}
