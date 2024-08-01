using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript2 : MonoBehaviour
{
    private ArenaScript arenaScript;

    public int EnemiesHit;

    private float timerLeft = 7;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //var enemyToRemove = arenaScript.enemies.FindIndex(arenaScript.enemies.BinarySearch(other.gameObject));
            Destroy(other.gameObject);
            EnemiesHit = EnemiesHit + 1;

            if (arenaScript != null)
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

    void Update()
    {
        if(EnemiesHit >= 3)
        {
            Destroy(gameObject);
            EnemiesHit = 0;
        }
    }

    void DestroyMe()
    {
        Destroy(gameObject);
    }
}
