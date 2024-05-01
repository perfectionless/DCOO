using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    public int maxHealth = 10;
    public int playerHealth;
    public int hullLevel = 1;
    public float damageInterval = 1f;
    public int zoneDamage = 0;
    public int collectionLevel = 1;
    public int collectedTrashValue = 0;
    public int playerScore = 0;
    public bool underLevel = false;
    void Start()
    {
        playerHealth = maxHealth;
        StartCoroutine(tickCheck());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        if(trigger.gameObject.tag == "Zone")
        {
            ZoneScript zoneScript = trigger.gameObject.GetComponent<ZoneScript>();

            if(zoneScript != null)
            {
                if(hullLevel < zoneScript.zoneLevel)
                {
                    underLevel = true;
                    zoneDamage = Mathf.Abs(hullLevel - zoneScript.zoneLevel);
                    Debug.Log("UPGRADE HULL LEVEL");

                }
                else
                {
                    underLevel = false;
                }
            }
        }

        if(trigger.gameObject.tag == "Deposit")
        {
            if(collectedTrashValue > 0)
            {
                playerScore += collectedTrashValue;
                collectedTrashValue = 0;
                Debug.Log("Trash deposited!" + "  Player score: " + playerScore);
            }
            else
            {
                Debug.Log("No trash collected yet!");
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Trash")
        {
            TrashScript trashScript = collision.gameObject.GetComponent<TrashScript>();

            if(trashScript != null)
            {
                if(collectionLevel < trashScript.trashTier)
                {
                    playerHealth -= Mathf.Abs(collectionLevel - trashScript.trashTier);
                    Debug.Log("-" + trashScript.trashTier.ToString() + " HP");
                    Debug.Log("UPGRADE COLLECTOR LEVEL");
                }
                else
                {
                    collectedTrashValue += trashScript.trashValue;
                    Debug.Log("Collected trash value: " + collectedTrashValue.ToString());
                    Destroy(collision.gameObject);
                }
            }

        }


    }
    

    IEnumerator tickCheck()
    {
        // Keep looping indefinitely
        while (true)
        {
            // Check if the condition is met
            if (underLevel)
            {
                // Perform the event here
                playerHealth -= zoneDamage;
                Debug.Log("-" + zoneDamage.ToString() + " HP");

            //    if(playerHealth <= 0)
            //     {
            //         Destroy(gameObject, 1f);
            //     }

                // Wait for X seconds before continuing to the next iteration
                yield return new WaitForSeconds(damageInterval);


            }
            else
            {
                // If condition is not met, wait for a short time before checking again
                yield return null;
            }
        }
    }
}
