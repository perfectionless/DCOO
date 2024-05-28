using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Revive : MonoBehaviour
{
    public GameObject PlayerChar;
    public Rigidbody2D PlayerPhysics;
    public GameObject reviveMenu;
    GameObject camra;

    public GameObject lossMsg;

    void Start()
    {
        camra = GameObject.Find("Main Camera");
    }
    public void REVIVE()
    {
        PlayerAttributes playerAttributes = PlayerChar.GetComponent<PlayerAttributes>();
        playerAttributes.playerHealth = playerAttributes.maxHealth;

        reviveMenu.SetActive(false);
        Time.timeScale = 1f;
    }

        public void DEAD()
    {
        PlayerAttributes playerAttributes = PlayerChar.GetComponent<PlayerAttributes>();
        playerAttributes.playerHealth = -999;
        playerAttributes.playerScore = 0;
        PlayerPhysics.gravityScale = -1;

        CameraMove camrascrip = camra.GetComponent<CameraMove>();
        Destroy(camrascrip);
        PlayerChar.GetComponent<PolygonCollider2D>().enabled = false;



        lossMsg.SetActive(!lossMsg.activeSelf);

        

        reviveMenu.SetActive(false);
        Time.timeScale = 1f;

    }

    // public void UpgradeSpeed()
    // {
    //     PlayerAttributes playerAttributes = PlayerChar.GetComponent<PlayerAttributes>();

    //     playerAttributes. += 1;
    //     // Update the text in the TextMeshPro component
    //     CollectionText.text = "Collection Level: " + playerAttributes.collectionLevel;
    // }
}
