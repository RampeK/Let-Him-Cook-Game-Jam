using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void PlayButtonClicked()
    {
        SceneManager.LoadScene("GameScene"); // Load your game scene
    }

    public void SettingsButtonClicked()
    {
        // Open settings screen or dialog
        Debug.Log("Settings button clicked");
    }

    public void CreditsButtonClicked()
    {
        // Show credits screen or dialog
        Debug.Log("Credits button clicked");
    }
}