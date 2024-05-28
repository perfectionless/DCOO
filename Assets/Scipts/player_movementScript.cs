using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movementScript : MonoBehaviour
{
  public float speed = 1;
  public float speedMax = 3;
  public double fuel = 10;
  public Rigidbody2D rb;
  private SpriteRenderer spriteRenderer;

  // Start is called before the first frame update
  void Start()
  {
    spriteRenderer = GetComponent<SpriteRenderer>();
  }

  // Update is called once per frame
  void Update()
  {
    Vector3 pos = transform.position;
    float moveX = Input.GetAxis("Horizontal");  // Get horizontal movement (-1 to 1)
    float moveY = Input.GetAxis("Vertical");    // Get vertical movement (-1 to 1)

    if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
    {


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


        // Combine movement into a direction vector
        Vector3 movement = new Vector3(moveX, moveY, 0f);

        // Update position based on movement and speed
        pos += movement * speed * Time.deltaTime;

        
        // Flip sprite on X-axis when moving left
        spriteRenderer.flipX = moveX < 0;

        fuel -= 0.001; // Fuel consumption for movement

        transform.position = pos;
      }

    }

  }
}
