using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript2 : MonoBehaviour
{
    public int EnemiesHit;

    private float timerLeft = 7;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            EnemiesHit = EnemiesHit + 1;
        }
        if (other.gameObject.tag == "Spike")
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
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
