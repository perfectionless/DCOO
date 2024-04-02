using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_collisionActions : MonoBehaviour
{

    public int score = 0;

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Trash"){
        Debug.Log("Entered collision");
        Destroy(collision.gameObject);
        score++;
        }

        if(collision.gameObject.name == "object_collectableTrashT2_coliDec"){
        Debug.Log("Entered collision");
        score+=5;
        }

        if(collision.gameObject.name == "object_collectableTrashT3_coliDec"){
        Debug.Log("Entered collision");
        score+=10;
        }
    }

    private void OnCollisionStay2D(Collision2D collision){
        if(collision.gameObject.name == "object_collectableTrash_coliDec"){
        Debug.Log("Maintaining collision");
        }
    }

    private void OnCollisionExit2D(Collision2D collision){
        if(collision.gameObject.name == "object_collectableTrash_coliDec"){
        Debug.Log("Exited collision");
        }            
    }
        
}
