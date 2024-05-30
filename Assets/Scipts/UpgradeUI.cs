using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeUI : MonoBehaviour
{
    public TextMeshProUGUI HullText;
    public TextMeshProUGUI CollectionText;
    public TextMeshProUGUI UpgradePointTExt;
    public GameObject needMorePoints;
    // public TextMeshProUGUI SpeedText;
    public GameObject PlayerChar;
    public int upgradePoint = 0;
    public int scoreTrack = 0; //useless POS
    public int upgradePointThreshhold  = 25;

    void Update()
    {
        PlayerAttributes playerAttributes = PlayerChar.GetComponent<PlayerAttributes>();
        UpgradePointTExt.text = "Upgrades (" + upgradePoint + ")";

        if (playerAttributes.playerScore >= upgradePointThreshhold)
        {
            upgradePointThreshhold += 25;
            upgradePoint += 1;
        }
    }


    public void UpgradeHull()
    {
        PlayerAttributes playerAttributes = PlayerChar.GetComponent<PlayerAttributes>();

        
        if(upgradePoint <= 0){
            needMorePoints.SetActive(true);
        }
        else {
            upgradePoint -= 1;
            playerAttributes.hullLevel += 1;
            // Update the text in the TextMeshPro component
            HullText.text = "Hull Level: " + playerAttributes.hullLevel;
        }
    }

        public void UpgradeCollection()
    {
        PlayerAttributes playerAttributes = PlayerChar.GetComponent<PlayerAttributes>();

       

        if(upgradePoint <= 0){
            needMorePoints.SetActive(true);
        }
        else{
            upgradePoint -= 1;
            playerAttributes.collectionLevel += 1;
            // Update the text in the TextMeshPro component
            CollectionText.text = "Collection Level: " + playerAttributes.collectionLevel;
        }
    }

    

    // public void UpgradeSpeed()
    // {
    //     PlayerAttributes playerAttributes = PlayerChar.GetComponent<PlayerAttributes>();

    //     playerAttributes. += 1;
    //     // Update the text in the TextMeshPro component
    //     CollectionText.text = "Collection Level: " + playerAttributes.collectionLevel;
    // }
}
