using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject PlayerChar;
    public Rigidbody2D PlayerPhysics;
    GameObject camra;

    public GameObject lossMsg;

    // Start is called before the first frame update
    void Start()
    {
        camra = GameObject.Find("Main Camera");        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AbortGame()
    {
        PlayerAttributes playerAttributes = PlayerChar.GetComponent<PlayerAttributes>();
        playerAttributes.playerHealth = -999;
        playerAttributes.fuel = -999;
        //playerAttributes.playerScore = 0;
        PlayerPhysics.gravityScale = -1;

        CameraMove camrascrip = camra.GetComponent<CameraMove>();
        Destroy(camrascrip);
        PlayerChar.GetComponent<PolygonCollider2D>().enabled = false;



        lossMsg.SetActive(!lossMsg.activeSelf);

        playerAttributes.isDead = true;
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
