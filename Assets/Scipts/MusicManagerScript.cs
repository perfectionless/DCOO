using UnityEngine;

public class MusicManagerScript : MonoBehaviour
{
    private static MusicManagerScript _instance;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If another MusicManager exists, destroy this one
            Destroy(gameObject);
        }
    }

    // Other music-related methods (e.g., Play, Pause, etc.) can be added here
}
