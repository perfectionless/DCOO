using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoveryPickup : MonoBehaviour
{
    public float HPRecoveryPercent = 0.25f;
    public float FuelRecoveryPercent = 0.25f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerAttributes playerAttributes = other.GetComponent<PlayerAttributes>();
            if (playerAttributes != null)
            {
                playerAttributes.playerHealth += playerAttributes.maxHealth*HPRecoveryPercent;                
                playerAttributes.fuel += playerAttributes.maxFuel*FuelRecoveryPercent;
                // Destroy the power-up GameObject or deactivate it
                // gameObject.SetActive(false);
                Destroy(gameObject);
            }
        }
    }
}
