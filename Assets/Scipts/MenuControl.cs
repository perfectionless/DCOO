using UnityEngine;

public class MenuControl : MonoBehaviour
{
    // Reference to the UpgradeMenu GameObject
    public GameObject upgradeMenu;
    public GameObject reviveMenu;
    public GameObject PlayerChar;

    void Start()
    {


    }

    void Update()
    {
        // Check if the 'P' key is pressed
        if (Input.GetKeyDown(KeyCode.P))
        {
            // Toggle the visibility of the UpgradeMenu
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
