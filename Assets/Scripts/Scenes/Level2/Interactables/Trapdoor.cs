using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trapdoor : MonoBehaviour
{
    [SerializeField] private GameObject trapdoor;
    [SerializeField] private GameObject interactUI;

    [SerializeField] private Text keyText;

    [SerializeField] private GameObject hands;

    private bool can = false;
    private bool can2 = true;

    void Start()
    {
        can = false;
        can2 = true;
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

        if (Input.GetKeyDown(inputToInteract) && can == true && hands == null)
            {
                print("ok");
                can = false;
                can2 = false;
                trapdoor.transform.position = new Vector3(trapdoor.transform.position.x + 15, trapdoor.transform.position.y, trapdoor.transform.position.z);
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player" && can2 == true)
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
    }