using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public GameObject GameOverCanvas;

    public void PlayButtonClicked()
    {
        SceneManager.LoadScene("Main Game Scene"); // Load your game scene
    }


    public void ReturnButtonClicked()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}