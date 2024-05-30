using UnityEngine;

public class MenuControl : MonoBehaviour
{
    // Reference to the UpgradeMenu GameObject
    public GameObject upgradeMenu;
    public GameObject reviveMenu;
    public GameObject PlayerChar;
    public GameObject pauseMenu;
    public GameObject needMorePoints;

    void Start()
    {


    }

    void Update()
    {

        

        PlayerAttributes playerAttributes = PlayerChar.GetComponent<PlayerAttributes>();
        // Check if the 'P' key is pressed
        if (Input.GetKeyDown(KeyCode.P) && playerAttributes.atMothership)
        {
            // Toggle the visibility of the UpgradeMenu
            needMorePoints.SetActive(false);
            upgradeMenu.SetActive(!upgradeMenu.activeSelf);

            // Pause or unpause the game depending on the active state of the UpgradeMenu
            if (upgradeMenu.activeSelf)
            {
                Time.timeScale = 0f; // Pause the game
            }
            else
            {
                Time.timeScale = 1f; // Unpause the game
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Toggle the visibility of the UpgradeMenu
            pauseMenu.SetActive(!pauseMenu.activeSelf);

            // Pause or unpause the game depending on the active state of the UpgradeMenu
            if (pauseMenu.activeSelf)
            {
                Time.timeScale = 0f; // Pause the game
            }
            else
            {
                Time.timeScale = 1f; // Unpause the game
            }
        }

        //death,destruction,failure
        DEATH();
    }

    void DEATH()
    {

        PlayerAttributes playerAttributes = PlayerChar.GetComponent<PlayerAttributes>();
        
        if (playerAttributes.playerHealth <= 0 && playerAttributes.playerHealth >= -100)
        {
            reviveMenu.SetActive(true);

            // Pause or unpause the game depending on the active state of DEATH
            if (reviveMenu.activeSelf)
            {
                Time.timeScale = 0f; // Pause the game
            }
            else
            {
                Time.timeScale = 1f; // Unpause the game
            }
        }

        if (playerAttributes.fuel <= 0 && playerAttributes.playerHealth >= -100)
        {
            reviveMenu.SetActive(true);

            // Pause or unpause the game depending on the active state of DEATH
            if (reviveMenu.activeSelf)
            {
                Time.timeScale = 0f; // Pause the game
            }
            else
            {
                Time.timeScale = 1f; // Unpause the game
            }
        }
    }
}
