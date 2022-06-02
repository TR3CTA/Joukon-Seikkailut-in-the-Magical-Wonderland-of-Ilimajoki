using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowSpawnManager : MonoBehaviour
{
    public GameObject[] cowPrefabs;

    private float startDelay = 4;
    private float spawnInterval = 1.5f;

    private float spawnRange = 62;
    private float spawnPosZ = 62;
    private float spawnPosX = 62;

    private bool gameActive;
    private bool stopInvoke;

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

    void SpawnRandomCow()
    {
        // Decide cows spawn point randomly and rotation based on that
        Vector3 northSpawn = new Vector3(Random.Range(-spawnRange, spawnRange), 1, spawnPosZ);
        Vector3 eastSpawn = new Vector3(spawnPosX, 1, Random.Range(-spawnRange, spawnRange));
        Vector3 southSpawn = new Vector3(Random.Range(-spawnRange, spawnRange), 1, -spawnPosZ);
        Vector3 westSpawn = new Vector3(-spawnPosX, 1, Random.Range(-spawnRange, spawnRange));

        Vector3[] spawnPositions = new[] { northSpawn, eastSpawn, southSpawn, westSpawn };

        int cowIndex = Random.Range(0, cowPrefabs.Length);
        Vector3 spawnPos = spawnPositions[Random.Range(0, 4)];
        int cowRotation;

        if (spawnPos == northSpawn)
        {
            cowRotation = 180;
        }
        else if (spawnPos == eastSpawn)
        {
            cowRotation = 270;
        }
        else if (spawnPos == southSpawn)
        {
            cowRotation = 0;
        }
        else
        {
            cowRotation = 90;
        }

        Instantiate(cowPrefabs[cowIndex], spawnPos, Quaternion.Euler(0, cowRotation, 0));
    }

    void StartSpawning()
    {
        // Spawn cows on random intervals
        InvokeRepeating("SpawnRandomCow", startDelay, spawnInterval);
    }
}
