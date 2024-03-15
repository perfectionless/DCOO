using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class UIManager : MonoBehaviour
{
    //[SerializeField]
    private TextMeshProUGUI scoreText;


    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();

        scoreText.text = "Score: ";

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //    public void updateScore(int Score)
}
