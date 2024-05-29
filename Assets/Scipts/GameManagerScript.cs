using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    public GameObject PlayerChar;
    public GameObject WarningMsg;
    public float blinkInterval = 0.5f; // Adjust this value to control the blinking speed
    private float timer = 0f;
    private bool isBlinking = false;
    public TextMeshProUGUI heldTrashText;
    public TextMeshProUGUI playerScoreText;
    float heldTrashValue;
    float playerScore;
    public TextMeshProUGUI finalScoretext;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerAttributes playerAttributes = PlayerChar.GetComponent<PlayerAttributes>();
        if(playerAttributes.isDead)
        {
            StartCoroutine(ReturnToMenu(3));
        }


        if(playerAttributes.underLevel)
        {
            if (!isBlinking)
            {
                // Start blinking
                isBlinking = true;
                WarningMsg.SetActive(true);
            }

            // Update the timer
            timer += Time.deltaTime;
            if (timer >= blinkInterval)
            {
                // Toggle visibility
                WarningMsg.SetActive(!WarningMsg.activeSelf);
                timer = 0f;
            }

        } else {
            isBlinking = false;
            WarningMsg.SetActive(false);
        }

        heldTrashValue = playerAttributes.collectedTrashValue;
        playerScore = playerAttributes.playerScore;
        float finalScore = playerScore;

        heldTrashText.text = "Held Trash Value: " + heldTrashValue.ToString();
        playerScoreText.text = "Score: " + playerScore.ToString();
        finalScoretext.text = "Final Score: " + finalScore.ToString();
        
    }


    IEnumerator ReturnToMenu(float duration)
    {
        yield return new WaitForSeconds(duration);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }
}
