using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movementScript : MonoBehaviour
{
    public float speed = 1;
    public float speedMax = 3;
    public double fuel = 10;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        if (fuel > 0)
        {
            // Movement with speed control using LeftShift
            if (Input.GetKey(KeyCode.LeftShift) && speed <= speedMax)
            {
                speed = speedMax;
                fuel -= 0.01;
            }
            else if (!Input.GetKey(KeyCode.LeftShift) && speed >= 1)
            {
                speed = 1;
            }

            // Movement and rotation based on key presses
            float moveX = Input.GetAxis("Horizontal");  // Get horizontal movement (-1 to 1)
            float moveY = Input.GetAxis("Vertical");    // Get vertical movement (-1 to 1)


            // Combine movement into a direction vector
            Vector3 movement = new Vector3(moveX, moveY, 0f);

            // Update position based on movement and speed
            pos += movement * speed * Time.deltaTime;

            // Check for any movement (excluding small values)
            if (movement.magnitude > 0.1f)
            {
                // Calculate desired rotation based on movement direction
                float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0, 0, angle);
            }

            fuel -= 0.001; // Fuel consumption for movement
        }

        transform.position = pos;





    }

}
