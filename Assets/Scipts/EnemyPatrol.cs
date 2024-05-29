using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float moveSpeed = 0.7f; // Speed of the enemy's movement
    public float patrolDistance = 5f; // Distance the enemy patrols left and right
    private Vector3 initialPosition; // Initial position of the enemy
    private Vector3 previousPosition;
    private SpriteRenderer spriteRenderer; // Reference to the sprite renderer component

    private void Start()
    {
        // Store the initial position of the enemy
        initialPosition = transform.position;

        // Get the SpriteRenderer component attached to the enemy
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // Calculate the new position for the enemy
        Vector3 newPosition = initialPosition + Vector3.right * Mathf.Sin(Time.time * moveSpeed) * patrolDistance;

        // Move the enemy to the new position
        previousPosition = transform.position;
        transform.position = newPosition;

        // Flip the sprite if moving right
        if (newPosition.x > previousPosition.x)
        {
            spriteRenderer.flipX = true; // Flip horizontally
        }
        else
        {
            spriteRenderer.flipX = false; // Reset the flip
        }
    }
}
