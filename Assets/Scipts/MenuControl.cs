using UnityEngine;

public class MenuControl : MonoBehaviour
{
    // Reference to the UpgradeMenu GameObject
    public GameObject upgradeMenu;

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
    }
}
