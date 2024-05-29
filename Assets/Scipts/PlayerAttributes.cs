using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    public float speed;
    private float originalSpeed;
    public float normalSpeed = 4;
    public float speedMax;
    public double fuel;
    public double maxFuel = 10;
    public float maxHealth = 100;
    public float playerHealth;
    public int hullLevel = 1;
    public float damageInterval = 1f;
    public int zoneDamage = 0;
    public int collectionLevel = 1;
    public int collectedTrashValue = 0;
    public int playerScore = 0;
    public bool underLevel = false;
    public bool hasUnlimitedFuel = false;
    public bool magnetic = false;
    public float trashMagnetRadius;
    private float magnetDuration;
    public GameObject magnetIndicator;
    public int activeZoneLevel;
    public bool isDead;
    public GameObject trashWarning;
    void Start()
    {
        originalSpeed = normalSpeed;
        speed = normalSpeed;
        speedMax = (float)(normalSpeed * 1.5);
        playerHealth = maxHealth;
        fuel = maxFuel;
        StartCoroutine(tickCheck());
        
    }

    // Update is called once per frame
    void Update()
    {
        if(magnetic) {
            ApplyTrashMagnet(trashMagnetRadius, magnetDuration);
            AttractTrashObjects();
        }

        if(playerHealth >= maxHealth)
        {
            playerHealth = maxHealth;
        }
        
        if(fuel >= maxFuel)
        {
            fuel = maxFuel;
        }

        if(!hasUnlimitedFuel)
        {
            fuel -= 0.0001;
        }
        
    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        if(trigger.gameObject.tag == "Zone")
        {
            ZoneScript zoneScript = trigger.gameObject.GetComponent<ZoneScript>();
            activeZoneLevel = zoneScript.zoneLevel;

            if(zoneScript != null)
            {
                if(hullLevel < activeZoneLevel)
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

        if(trigger.gameObject.tag == "Deposit" && !isDead)
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

        if(trigger.gameObject.tag == "Trash" &&!isDead)
        {
            TrashScript trashScript = trigger.gameObject.GetComponent<TrashScript>();

            if(trashScript != null)
            {
                if(collectionLevel < trashScript.trashTier)
                {
                    playerHealth -= Mathf.Abs(collectionLevel - trashScript.trashTier);
                    Debug.Log("-" + trashScript.trashTier.ToString() + " HP");
                    Debug.Log("UPGRADE COLLECTOR LEVEL");
                    StartCoroutine(trashWarn(2));
                }
                else
                {
                    collectedTrashValue += trashScript.trashValue;
                    Debug.Log("Collected trash value: " + collectedTrashValue.ToString());
                    Destroy(trigger.gameObject);
                }
            }

        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {


        if(collision.gameObject.tag == "Enemy") 
        {
            playerHealth = 0;
        }


    }

    public void ApplySpeedBoost(float factor, float duration)
    {
        normalSpeed = originalSpeed * factor;
        speedMax = (float)(normalSpeed * 1.5);
        hasUnlimitedFuel = true;
        
        StartCoroutine(RevertSpeedAfterDuration(duration));

    }

    public void ApplyTrashMagnet(float magnetRadius, float magnetDuration)
    {
        if (!magnetic)
        {
            StartCoroutine(ActivateTrashMagnet(magnetRadius, magnetDuration));
        }
    }

        private void AttractTrashObjects()
    {
        Collider2D[] trashColliders = Physics2D.OverlapCircleAll(transform.position, trashMagnetRadius);

        foreach (Collider2D trashCollider in trashColliders)
        {
            if (trashCollider.CompareTag("Trash"))
            {
                Rigidbody2D trashRigidbody = trashCollider.GetComponent<Rigidbody2D>();
                if (trashRigidbody != null)
                {
                    Vector2 directionToPlayer = transform.position - trashCollider.transform.position;
                    trashRigidbody.AddForce(directionToPlayer.normalized * 1f); // Adjust force as needed
                }
            }
        }
    }

    IEnumerator ActivateTrashMagnet(float radius, float duration)
    {
        trashMagnetRadius = radius;
        magnetic = true;
        collectionLevel += 99;
        Debug.Log(magnetIndicator.transform.localScale);
        magnetIndicator.transform.localScale = magnetIndicator.transform.localScale * radius;
        Debug.Log(magnetIndicator.transform.localScale);
        magnetIndicator.SetActive(true);
        // Optionally, play a sound or visual effect to indicate the trash magnet activation

        // Keep the magnet active for the specified duration
        yield return new WaitForSeconds(duration);

        // Optionally, play a sound or visual effect to indicate the end of the magnet effect
        magnetIndicator.transform.localScale = magnetIndicator.transform.localScale / radius;
        magnetic = false;
        magnetIndicator.SetActive(false);
        collectionLevel -= 99;
    }

    IEnumerator RevertSpeedAfterDuration(float duration)
    {
        yield return new WaitForSeconds(duration);

        // Revert the speed back to the original value
        normalSpeed = originalSpeed;
        speed = normalSpeed;
        speedMax = (float)(normalSpeed * 1.5);
        hasUnlimitedFuel = false;
    }

    IEnumerator trashWarn(float duration)
    {
        trashWarning.SetActive(true);
        yield return new WaitForSeconds(duration);
        trashWarning.SetActive(false);
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
