using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    public float speedBoostFactor = 2f; // Increase speed by this factor
    public float duration = 5f; // Duration of the speed boost

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerAttributes playerAttributes = other.GetComponent<PlayerAttributes>();
            if (playerAttributes != null)
            {
                playerAttributes.ApplySpeedBoost(speedBoostFactor, duration);
                // Destroy the power-up GameObject or deactivate it
                // gameObject.SetActive(false);
                Destroy(gameObject);
            }
        }
    }
}
