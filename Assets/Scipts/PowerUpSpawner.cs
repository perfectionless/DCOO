using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
public GameObject[] T1Powerups; // Array of tier 1 powerup variants
public GameObject[] T2Powerups; // Array of tier 2 powerup variants
public GameObject[] T3Powerups; // Array of tier 3 powerup variants
public float minSpawnInterval = 2f; // Minimum time between spawns
public float maxSpawnInterval = 8f; // Maximum time between spawns
public int maxPowerupCount = 5; // Maximum number of powerups in the game
private float nextSpawnTime;
private int currentPowerupCount;
public GameObject PlayerChar;

    // Start is called before the first frame update
    void Start()
    {
        nextSpawnTime = Time.time + Random.Range(minSpawnInterval, maxSpawnInterval);
        
    }

    // Update is called once per frame
    void Update()
    {
        currentPowerupCount = GameObject.FindGameObjectsWithTag("Powerup").Length;
        // Check if it's time to spawn
        if (Time.time >= nextSpawnTime && currentPowerupCount < maxPowerupCount)
        {
            SpawnPowerup();
            // Calculate the next spawn time
            nextSpawnTime = Time.time + Random.Range(minSpawnInterval, maxSpawnInterval);
        }

    }

    private GameObject GetRandomVariant(GameObject[] variants)
    {
        int randomIndex = Random.Range(0, variants.Length);
        return variants[randomIndex];
    }

    void SpawnPowerup()
    {
        float randomValue = Random.value; // Random value between 0 and 1        

        if (randomValue < 0.4f) // Adjust this threshold as needed
        {
            GameObject selectedVariant = GetRandomVariant(T1Powerups);
            Instantiate(selectedVariant, GetRandomSpawnPoint(), Quaternion.identity);
        }
        else if (randomValue < 0.7f)
        {
            GameObject selectedVariant = GetRandomVariant(T2Powerups);
            Instantiate(selectedVariant, GetRandomSpawnPoint(), Quaternion.identity);
        }
        else
        {
            GameObject selectedVariant = GetRandomVariant(T3Powerups);
            Instantiate(selectedVariant, GetRandomSpawnPoint(), Quaternion.identity);
        }
    }

    Vector3 GetRandomSpawnPoint()
    {
        float minX, maxX, minY, maxY;
        PlayerAttributes playerAttributes = PlayerChar.GetComponent<PlayerAttributes>();


        // Choose a random zone (L1, L2, or L3) and return the corresponding spawn point
        int activeZone = playerAttributes.activeZoneLevel; // 1, 2, or 3
        switch (activeZone)
        {
            case 1: // ZoneL1
                minX = (float)-8.5;
                maxX = (float)8.5;
                minY = (float)3.8;
                maxY = (float)-3.8;
                break;
            case 2: // ZoneL2
                minX = (float)-8.5;
                maxX = (float)8.5;
                minY = -6;
                maxY = -14;
                break;
            case 3: // ZoneL3
                minX = (float)-8.5;
                maxX = (float)8.5;
                minY = -16;
                maxY = -24;
                break;
            default:
                return Vector3.zero; // Fallback (shouldn't happen)
        }

        // Generate random position within the zone boundaries
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        return new Vector3(randomX, randomY, 0f); // Z-coordinate is 0 for 2D
        }

    }
