using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject SettingsCanvas;
    public GameObject MainMenuCanvas;
    public GameObject CreditsCanvas;

    public void PlayButtonClicked()
    {
        SceneManager.LoadScene("Main Game Scene"); // Load your game scene
    }

    public void SettingsButtonClicked()
    {
        SettingsCanvas.SetActive(true);
        MainMenuCanvas.SetActive(false);
        Debug.Log("Settings button clicked");
    }

    public void CreditsButtonClicked()
    {
        CreditsCanvas.SetActive(true);
        MainMenuCanvas.SetActive(false);
        Debug.Log("Credits button clicked");
    }

    public void ReturnButtonClicked()
    {
        MainMenuCanvas.SetActive(true);
        SettingsCanvas.SetActive(false);
        CreditsCanvas.SetActive(false);
    }
}