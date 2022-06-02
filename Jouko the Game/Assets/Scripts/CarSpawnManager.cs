using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawnManager : MonoBehaviour
{
    public GameObject[] carPrefabs;

    private float startDelay = 5;
    private float spawnInterval = 3;

    private bool gameActive;
    private bool stopInvoke;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameActive = GameObject.Find("Game Manager").GetComponent<GameManager>().gameActive;

        if (gameActive && !stopInvoke)
        {
            stopInvoke = true;
            StartSpawning();
        }
    }

    void SpawnRandomCar()
    {
        // Decide cars spawn point randomly and rotation based on that
        Vector3 northSpawn = new Vector3(-42, 3, 60);
        Vector3 eastSpawn = new Vector3(60, 3, 16.5f);
        Vector3 southSpawn = new Vector3(-37, 3, -60);
        Vector3 westSpawn = new Vector3(-60, 3, 10.5f);
 
        Vector3[] spawnPositions = new[] { northSpawn, eastSpawn, southSpawn, westSpawn };

        int carIndex = Random.Range(0, carPrefabs.Length);
        Vector3 spawnPos = spawnPositions[Random.Range(0, 4)];
        int carRotation;

        if (spawnPos == northSpawn)
        {
            carRotation = 180;
        }
        else if (spawnPos == eastSpawn)
        {
            carRotation = 270;
        }
        else if (spawnPos == southSpawn)
        {
            carRotation = 0;
        }
        else
        {
            carRotation = 90;
        }

        Instantiate(carPrefabs[carIndex], spawnPos, Quaternion.Euler(0, carRotation, 0));
    }

    void StartSpawning()
    {
        // Spawn cars on random intervals
        InvokeRepeating("SpawnRandomCar", startDelay, spawnInterval);
    }
}
