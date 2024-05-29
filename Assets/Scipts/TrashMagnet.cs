using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashMagnet : MonoBehaviour
{
    public float radius = 3f; // magnet range
    public float duration = 5f; // Duration

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerAttributes playerAttributes = other.GetComponent<PlayerAttributes>();
            if (playerAttributes != null)
            {
                playerAttributes.ApplyTrashMagnet(radius, duration);
                playerAttributes.magnetic = true;
                // Destroy the power-up GameObject or deactivate it
                // gameObject.SetActive(false);
                Destroy(gameObject);
            }
        }
    }
}
