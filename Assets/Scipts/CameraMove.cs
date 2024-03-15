using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform target; // Reference to the player's transform
    public Vector3 offset;   // Offset from the target position

    void Update()
    {
        if (target != null)
        {
            // Get the player's position, ignoring the y-axis
            Vector3 targetPosition = new Vector3(transform.position.x, target.position.y, transform.position.z);

            // Set the camera's position to the player's position (x) plus the offset
            transform.position = targetPosition + offset;
        }
    }
}


