using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixIngredients : MonoBehaviour
{
    public Animator animator;
    public Animator secondaryAnimator; 
    public Animator tertiaryAnimator; 
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
            tertiaryAnimator.SetTrigger("R‰j‰hdys");
            secondaryAnimator.SetTrigger("R‰j‰hdysMovement");
            tertiaryAnimator.SetTrigger("Mikro");
            animator.SetTrigger("KulhoMikroon");
        }
        else if (score <= 99)
        {
            // Score 2 triggers
            secondaryAnimator.SetTrigger("Valmis");
            secondaryAnimator.SetTrigger("Huono");
            secondaryAnimator.SetTrigger("ValmisMovement");
            tertiaryAnimator.SetTrigger("Mikro");
            animator.SetTrigger("KulhoMikroon");
            animator.SetTrigger("KulhoPudotus");
        }
        else if (score <= 129)
        {
            // Score 3 triggers
            secondaryAnimator.SetTrigger("Valmis");
            secondaryAnimator.SetTrigger("Mid");
            secondaryAnimator.SetTrigger("ValmisMovement");
            tertiaryAnimator.SetTrigger("Mikro");
            animator.SetTrigger("KulhoMikroon");
        }
        else if (score <= 149)
        {
            // Score 4 triggers
            secondaryAnimator.SetTrigger("Valmis");
            secondaryAnimator.SetTrigger("Ookoo");
            secondaryAnimator.SetTrigger("ValmisMovement");
            tertiaryAnimator.SetTrigger("Mikro");
            animator.SetTrigger("KulhoMikroon");
        }
        else if (score <= 199)
        {
            // Score 5 triggers
            secondaryAnimator.SetTrigger("Valmis");
            secondaryAnimator.SetTrigger("Hyv‰");
            secondaryAnimator.SetTrigger("ValmisMovement");
            tertiaryAnimator.SetTrigger("Mikro");
            animator.SetTrigger("KulhoMikroon");
            animator.SetTrigger("KulhoSyˆnti");
        }
        else
        {
            // Score 6 triggers
            secondaryAnimator.SetTrigger("Valmis");
            secondaryAnimator.SetTrigger("Loistava");
            secondaryAnimator.SetTrigger("ValmisMovement");
            secondaryAnimator.SetTrigger("LoistavaMovement");
            tertiaryAnimator.SetTrigger("Mikro");
            animator.SetTrigger("KulhoMikroon");
            animator.SetTrigger("KulhoPudotus");
        }
    }

    public void MixIngredientsButtonClicked()
    {
        int currentScore = plate.GetTotalPoints();
        Debug.Log("Current Score: " + currentScore); // T‰m‰ tulostaa pistem‰‰r‰n konsoliin.
        UpdateAnimationsBasedOnScore(currentScore);

        float delay = (currentScore <= 50) ? 10.0f : 15.0f;
        Debug.Log("Invoke Delay: " + delay); // T‰m‰ tulostaa viiveen konsoliin.

        Invoke("ShowGameOverScreen", delay);
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