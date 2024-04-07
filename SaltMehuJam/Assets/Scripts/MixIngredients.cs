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

    public AudioSource src;
    public AudioClip sound1, sound2, sound3, sound4, sound5, sound6;


        // Metodi, joka p�ivitt�� animaatiot pistem��r�n mukaan
        public void UpdateAnimationsBasedOnScore(int score)
    {
        // Ensin nollataan kaikki animaatiot
        ResetAllTriggers();

        // K�ynnistet��n eri animaatiot riippuen pistem��r�st�
        if (score <= 50)
        {
            // Score 1 triggers
            tertiaryAnimator.SetTrigger("R�j�hdys");
            secondaryAnimator.SetTrigger("R�j�hdysMovement");
            tertiaryAnimator.SetTrigger("Mikro");
            animator.SetTrigger("KulhoMikroon");

            Invoke("ShowGameOverScreen", 6.8f);

            src.clip = sound1;
            src.Play();
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

            Invoke("ShowGameOverScreen", 15.0f);

            src.clip = sound2;
            src.Play();
        }
        else if (score <= 129)
        {
            // Score 3 triggers
            secondaryAnimator.SetTrigger("Valmis");
            secondaryAnimator.SetTrigger("Mid");
            secondaryAnimator.SetTrigger("ValmisMovement");
            tertiaryAnimator.SetTrigger("Mikro");
            animator.SetTrigger("KulhoMikroon");

            Invoke("ShowGameOverScreen", 15.0f);

            src.clip = sound3;
            src.Play();
        }
        else if (score <= 149)
        {
            // Score 4 triggers
            secondaryAnimator.SetTrigger("Valmis");
            secondaryAnimator.SetTrigger("Ookoo");
            secondaryAnimator.SetTrigger("ValmisMovement");
            tertiaryAnimator.SetTrigger("Mikro");
            animator.SetTrigger("KulhoMikroon");

            Invoke("ShowGameOverScreen", 15.0f);

            src.clip = sound4;
            src.Play();
        }
        else if (score <= 199)
        {
            // Score 5 triggers
            secondaryAnimator.SetTrigger("Valmis");
            secondaryAnimator.SetTrigger("Hyv�");
            secondaryAnimator.SetTrigger("ValmisMovement");
            tertiaryAnimator.SetTrigger("Mikro");
            animator.SetTrigger("KulhoMikroon");
            animator.SetTrigger("KulhoSy�nti");

            Invoke("ShowGameOverScreen", 18.0f);

            src.clip = sound5;
            src.Play();
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

            Invoke("ShowGameOverScreen", 21.0f);

            src.clip = sound6;
            src.Play();
        }
    }

    public void MixIngredientsButtonClicked()
    {
        int currentScore = plate.GetTotalPoints();
        Debug.Log("Current Score: " + currentScore); // T�m� tulostaa pistem��r�n konsoliin.
        UpdateAnimationsBasedOnScore(currentScore);

       
        // Voit asettaa t�m�n arvon sopivaksi animaatioidesi keston mukaan
        
    }

    private void ShowGameOverScreen()
    {
        GameOverCanvas.SetActive(true);
    }

    // Nollaa kaikki triggerit varmistaaksemme, ett� animaatiot eiv�t j�� p��lle
    private void ResetAllTriggers()
    {
        var triggers = new List<string>
        {
            "R�j�hdys", "Valmis", "Huono", "Mid", "Ookoo", "Hyv�", "Loistava",
            "R�j�hdysMovement", "ValmisMovement", "LoistavaMovement", "Mikro"
        };

        foreach (var trigger in triggers)
        {
            animator.ResetTrigger(trigger);
        }
    }
}