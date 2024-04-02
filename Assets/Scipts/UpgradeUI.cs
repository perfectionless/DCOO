using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeUI : MonoBehaviour
{
    public TextMeshProUGUI HullText;
    public TextMeshProUGUI CollectionText;
    // public TextMeshProUGUI SpeedText;
    public GameObject PlayerChar;
    public void UpgradeHull()
    {
        PlayerAttributes playerAttributes = PlayerChar.GetComponent<PlayerAttributes>();

        playerAttributes.hullLevel += 1;
        // Update the text in the TextMeshPro component
        HullText.text = "Hull Level: " + playerAttributes.hullLevel;
    }

        public void UpgradeCollection()
    {
        PlayerAttributes playerAttributes = PlayerChar.GetComponent<PlayerAttributes>();

        playerAttributes.collectionLevel += 1;
        // Update the text in the TextMeshPro component
        CollectionText.text = "Collection Level: " + playerAttributes.collectionLevel;
    }

    // public void UpgradeSpeed()
    // {
    //     PlayerAttributes playerAttributes = PlayerChar.GetComponent<PlayerAttributes>();

    //     playerAttributes. += 1;
    //     // Update the text in the TextMeshPro component
    //     CollectionText.text = "Collection Level: " + playerAttributes.collectionLevel;
    // }
}
