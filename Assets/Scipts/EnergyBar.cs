using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    public Slider energySlider;
    public GameObject PlayerChar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    PlayerAttributes playerAttributes = PlayerChar.GetComponent<PlayerAttributes>();
    double energyPercentage = (playerAttributes.fuel / playerAttributes.maxFuel) * 100;
    energySlider.value = (float)energyPercentage;

        
    }
}
