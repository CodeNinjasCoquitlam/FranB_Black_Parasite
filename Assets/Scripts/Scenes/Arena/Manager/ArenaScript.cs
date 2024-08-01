using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArenaScript : MonoBehaviour
{
    [SerializeField] private GameObject endUI;

    [SerializeField] private Text waveText;

    [SerializeField] private GameObject ammoBox;
    [SerializeField] private GameObject enemy;

    [SerializeField] private GameObject spawn1;
    [SerializeField] private GameObject spawn2;

    [SerializeField] private GameObject enemySpawn1;
    [SerializeField] private GameObject enemySpawn2;

    private Vector3 spawnpos;

    private int waves = 0;

    private int enemiesPerWave;
    private int enemiesNeededToSpawn = 2;

    private bool waveOn = false;
    private bool countdown = false;

    [SerializeField] public List<GameObject> enemies = new List<GameObject>();

    void Update()
    {
        waveText.text = "Wave: " + waves;

        if(countdown == false)
        {
            countdown = true;
            spawnpos = new Vector3(Random.Range(spawn1.transform.position.x, spawn2.transform.position.x), spawn1.transform.position.y, spawn1.transform.position.z);
            Instantiate(ammoBox, spawnpos, ammoBox.transform.rotation);
            Invoke("CountdownFalse", 5);
        }

        if(waveOn == false)
        {
            waveOn = true;

            for (int i = 0; i < enemiesNeededToSpawn; i++)
            {
                var spawn = Random.Range(1, 3);

                print(spawn);
                if (spawn <= 1.5)
                {
                    var enemyObj = Instantiate(enemy, enemySpawn1.transform.position, enemySpawn1.transform.rotation);

                    enemies.Add(enemyObj);
                }

                if (spawn > 1.5)
                {
                    var enemyObj = Instantiate(enemy, enemySpawn2.transform.position, enemySpawn2.transform.rotation);

                    enemies.Add(enemyObj);
                }
            }
        }

        if(enemies.Count == 0)
        {
            NewWave();
        }

        if (waves == 99)
        {
            waveText.text = "Final Wave: 99";
        }
        if (waves == 100)
        {
            endUI.SetActive(true);
            waveText.text = "The End Wave: 100";
            Time.timeScale = 0;
        }
    }

    void CountdownFalse()
    {
        countdown = false;
    }

    void NewWave()
    {
        waveOn = false;
        enemiesNeededToSpawn = enemiesNeededToSpawn + 2;
        waves = waves + 1;
    }
}
