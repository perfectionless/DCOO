using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
public GameObject[] trashT1Variants; // Array of TrashT1 variants
public GameObject[] trashT2Variants; // Array of TrashT2 variants
public GameObject[] trashT3Variants; // Array of TrashT3 variants
public float minSpawnInterval = 2f; // Minimum time between spawns
public float maxSpawnInterval = 5f; // Maximum time between spawns
public int maxTrashCount = 10; // Maximum number of trash objects in the game
private float nextSpawnTime;
private int currentTrashCount;
public GameObject PlayerChar;

    // Start is called before the first frame update
    void Start()
    {
        nextSpawnTime = Time.time + Random.Range(minSpawnInterval, maxSpawnInterval);
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTrashCount = GameObject.FindGameObjectsWithTag("Trash").Length;
        // Check if it's time to spawn
        if (Time.time >= nextSpawnTime && currentTrashCount < maxTrashCount)
        {
            SpawnTrash();
            // Calculate the next spawn time
            nextSpawnTime = Time.time + Random.Range(minSpawnInterval, maxSpawnInterval);
        }

    }

    private GameObject GetRandomVariant(GameObject[] variants)
    {
        int randomIndex = Random.Range(0, variants.Length);
        return variants[randomIndex];
    }

    void SpawnTrash()
    {
        float randomValue = Random.value; // Random value between 0 and 1
        PlayerAttributes playerAttributes = PlayerChar.GetComponent<PlayerAttributes>();
        int activeZone = playerAttributes.activeZoneLevel;
        
        if(activeZone == 1)
        {
            if (randomValue < 0.9f) // Adjust this threshold as needed
            {
                GameObject selectedVariant = GetRandomVariant(trashT1Variants);
                Instantiate(selectedVariant, GetRandomSpawnPoint(), Quaternion.identity);
            }
            else
            {
                GameObject selectedVariant = GetRandomVariant(trashT2Variants);
                Instantiate(selectedVariant, GetRandomSpawnPoint(), Quaternion.identity);
            }
        } else if(activeZone == 2)
        {
            if (randomValue < 0.6f) // Adjust this threshold as needed
            {
                GameObject selectedVariant = GetRandomVariant(trashT1Variants);
                Instantiate(selectedVariant, GetRandomSpawnPoint(), Quaternion.identity);
            }
            else if (randomValue < 0.9f)
            {
                GameObject selectedVariant = GetRandomVariant(trashT2Variants);
                Instantiate(selectedVariant, GetRandomSpawnPoint(), Quaternion.identity);
            }
            else
            {
                GameObject selectedVariant = GetRandomVariant(trashT3Variants);
                Instantiate(selectedVariant, GetRandomSpawnPoint(), Quaternion.identity);
            }
        } else if(activeZone == 3)
        {
            if (randomValue < 0.1f) // Adjust this threshold as needed
            {
                GameObject selectedVariant = GetRandomVariant(trashT1Variants);
                Instantiate(selectedVariant, GetRandomSpawnPoint(), Quaternion.identity);
            }
            else if (randomValue < 0.5f)
            {
                GameObject selectedVariant = GetRandomVariant(trashT2Variants);
                Instantiate(selectedVariant, GetRandomSpawnPoint(), Quaternion.identity);
            }
            else
            {
                GameObject selectedVariant = GetRandomVariant(trashT3Variants);
                Instantiate(selectedVariant, GetRandomSpawnPoint(), Quaternion.identity);
            }
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
