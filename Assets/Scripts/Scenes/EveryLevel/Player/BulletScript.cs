using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private float timerLeft = 7.5f;
    private ArenaScript arenaScript;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {

            Destroy(gameObject);
            Destroy(other.gameObject);
            
            if(arenaScript != null)
            {
                arenaScript.enemies.Remove(other.gameObject);
            }
        }
        if (other.gameObject.tag == "Spike")
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        arenaScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ArenaScript>();

        Invoke("DestroyMe", timerLeft);

        if (PlayerPrefs.GetString("ReduceLag") == "True")
        {
            timerLeft = timerLeft - 2;
        }
        else
        {
            print("reduce lag no");
        }

        Invoke("DestroyMe", timerLeft);
    }

    void DestroyMe()
    {
        Destroy(gameObject);
    }
}
