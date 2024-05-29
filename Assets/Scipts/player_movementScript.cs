using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movementScript : MonoBehaviour
{
  public GameObject PlayerChar;
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
    PlayerAttributes playerAttributes = PlayerChar.GetComponent<PlayerAttributes>();
    
    Vector3 pos = transform.position;
    float moveX = Input.GetAxis("Horizontal");  // Get horizontal movement (-1 to 1)
    float moveY = Input.GetAxis("Vertical");    // Get vertical movement (-1 to 1)

    if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
    {


    if (playerAttributes.fuel > 0)
    {
      

        // Movement with speed control using LeftShift
        if (Input.GetKey(KeyCode.LeftShift) && playerAttributes.speed <= playerAttributes.speedMax)
        {
          playerAttributes.speed = playerAttributes.speedMax;

          if(!playerAttributes.hasUnlimitedFuel)
          {
            playerAttributes.fuel -= 0.01;

          }
        }
        else if (!Input.GetKey(KeyCode.LeftShift) && playerAttributes.speed >= 1)
        {
          playerAttributes.speed = playerAttributes.normalSpeed;
        }


        // Combine movement into a direction vector
        Vector3 movement = new Vector3(moveX, moveY, 0f);

        // Update position based on movement and speed
        pos += movement * playerAttributes.speed * Time.deltaTime;

        
        // Flip sprite on X-axis when moving left
        spriteRenderer.flipX = moveX > 0;
        
        if(!playerAttributes.hasUnlimitedFuel)
        {
          playerAttributes.fuel -= 0.001; // Fuel consumption for movement

        }


        transform.position = pos;
      }

    }

  }

}
