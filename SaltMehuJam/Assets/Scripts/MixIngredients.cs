using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixIngredients : MonoBehaviour
{
    public Animator animator;
    public Plate plate;
    public GameObject GameOverCanvas;

    // Metodi, joka p‰ivitt‰‰ animaatiot pistem‰‰r‰n mukaan
    public void UpdateAnimationsBasedOnScore(int score)
    {
        // Ensin nollataan kaikki animaatiot
        ResetAllTriggers();

        // K‰ynnistet‰‰n eri animaatiot riippuen pistem‰‰r‰st‰
        if (score <= 50)
        {
            // Score 1 triggers
            animator.SetTrigger("R‰j‰hdys");
            animator.SetTrigger("R‰j‰hdysMovement");
            animator.SetTrigger("Mikro");
            animator.SetTrigger("KulhoMikroon");
        }
        else if (score <= 99)
        {
            // Score 2 triggers
            animator.SetTrigger("Valmis");
            animator.SetTrigger("Huono");
            animator.SetTrigger("ValmisMovement");
            animator.SetTrigger("Mikro");
            animator.SetTrigger("KulhoMikroon");
            animator.SetTrigger("KulhoPudotus");
        }
        else if (score <= 129)
        {
            // Score 3 triggers
            animator.SetTrigger("Valmis");
            animator.SetTrigger("Mid");
            animator.SetTrigger("ValmisMovement");
            animator.SetTrigger("Mikro");
            animator.SetTrigger("KulhoMikroon");
        }
        else if (score <= 149)
        {
            // Score 4 triggers
            animator.SetTrigger("Valmis");
            animator.SetTrigger("Ookoo");
            animator.SetTrigger("ValmisMovement");
            animator.SetTrigger("Mikro");
            animator.SetTrigger("KulhoMikroon");
        }
        else if (score <= 199)
        {
            // Score 5 triggers
            animator.SetTrigger("Valmis");
            animator.SetTrigger("Hyv‰");
            animator.SetTrigger("ValmisMovement");
            animator.SetTrigger("Mikro");
            animator.SetTrigger("KulhoMikroon");
            animator.SetTrigger("KulhoSyˆnti");
        }
        else
        {
            // Score 6 triggers
            animator.SetTrigger("Valmis");
            animator.SetTrigger("Loistava");
            animator.SetTrigger("ValmisMovement");
            animator.SetTrigger("LoistavaMovement");
            animator.SetTrigger("Mikro");
            animator.SetTrigger("KulhoMikroon");
            animator.SetTrigger("KulhoPudotus");
        }
    }

    // Kutsutaan t‰t‰, kun sekoitusnappia painetaan
    public void MixIngredientsButtonClicked()
    {
        // Haetaan pistem‰‰r‰ Plate-skriptist‰
        int currentScore = plate.GetTotalPoints();
        UpdateAnimationsBasedOnScore(currentScore);

       
        // Voit asettaa t‰m‰n arvon sopivaksi animaatioidesi keston mukaan
        Invoke("ShowGameOverScreen", 5.0f);
    }

    private void ShowGameOverScreen()
    {
        GameOverCanvas.SetActive(true);
    }

    // Nollaa kaikki triggerit varmistaaksemme, ett‰ animaatiot eiv‰t j‰‰ p‰‰lle
    private void ResetAllTriggers()
    {
        var triggers = new List<string>
        {
            "R‰j‰hdys", "Valmis", "Huono", "Mid", "Ookoo", "Hyv‰", "Loistava",
            "R‰j‰hdysMovement", "ValmisMovement", "LoistavaMovement", "Mikro"
        };

        foreach (var trigger in triggers)
        {
            animator.ResetTrigger(trigger);
        }
    }
}