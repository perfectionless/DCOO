using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public GameObject PlayerChar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    PlayerAttributes playerAttributes = PlayerChar.GetComponent<PlayerAttributes>();
    double healthPercentage = (playerAttributes.playerHealth / playerAttributes.maxHealth) * 100;
    healthSlider.value = (float)healthPercentage;

        
    }
}
