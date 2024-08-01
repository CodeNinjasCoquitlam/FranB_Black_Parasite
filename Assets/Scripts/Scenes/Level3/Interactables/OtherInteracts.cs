using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OtherInteracts : MonoBehaviour
{
    private bool CanGetIn;
    private bool CanGetIn2;
    private bool CanFinish;

    private bool wiresOn = true;

    [SerializeField] private GameObject interactUI;

    [SerializeField] private Text keyToInteract;

    [SerializeField] private Transform teleportPlace;
    [SerializeField] private Transform teleportPlace1;

    [SerializeField] private GameObject wires;
    [SerializeField] private GameObject wires2;

    [SerializeField] private ParticleSystem wiresP;
    [SerializeField] private ParticleSystem wires2P;

    [SerializeField] private bool onElectrical = false;

    [SerializeField] private GameObject gameManager;

    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager");
    }

    void Update()
    {
        if (CanGetIn2 == true && Input.GetKeyDown(KeyCode.E))
        {
            if (wiresOn == true)
            {
                gameManager.GetComponent<AudioSource>().Play(0);
                wiresP.Stop();
                wires2P.Stop();
            }
            else
            {
                gameManager.GetComponent<AudioSource>().Play(0);
                wiresP.Play();
                wires2P.Play();
            }

            wires.GetComponent<BoxCollider2D>().enabled = !wires.GetComponent<BoxCollider2D>().enabled;
            wires2.GetComponent<BoxCollider2D>().enabled = !wires2.GetComponent<BoxCollider2D>().enabled;

            wiresOn = !wiresOn;
        }

        if(CanFinish == true && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("FinalCutscene");
        }

        if (teleportPlace != null)
        {
            if (CanGetIn == true && Input.GetKeyDown(KeyCode.E))
            {

                if (onElectrical == true)
                {
                    gameObject.transform.position = new Vector2(teleportPlace1.transform.position.x, teleportPlace1.transform.position.y);
                }
                else
                {
                    gameObject.transform.position = new Vector2(teleportPlace.transform.position.x, teleportPlace.transform.position.y);
                }
                onElectrical = !onElectrical;
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -0.2f);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ElectricityDoor")
        {
            CanGetIn = true;
            interactUI.SetActive(true);
            keyToInteract.text = "E";
        }
        if (other.gameObject.tag == "ElectricalBox")
        {
            CanGetIn2 = true;
            interactUI.SetActive(true);
            keyToInteract.text = "E";
        }
        if (other.gameObject.tag == "FinishButton")
        {
            CanFinish = true;
            interactUI.SetActive(true);
            keyToInteract.text = "E";
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "ElectricityDoor")
        {
            CanGetIn = false;
            interactUI.SetActive(false);
        }
        if (other.gameObject.tag == "ElectricalBox")
        {
            CanGetIn2 = false;
            interactUI.SetActive(false);
        }
        if (other.gameObject.tag == "FinishButton")
        {
            CanFinish = false;
            interactUI.SetActive(false);
        }
    }
}
