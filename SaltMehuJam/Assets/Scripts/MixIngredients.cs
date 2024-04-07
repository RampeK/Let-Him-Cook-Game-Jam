using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MixIngredients : MonoBehaviour
{
    public GameObject explosionEffectPrefab;
    public TextMeshProUGUI scoreNumberText;
    public GameObject Music;
    public GameObject EndMusic;
    public GameObject AnimatorCaveman;
    public GameObject AnimatorMicro;
    public GameObject AnimatorBowl;
    public GameObject PlayerCharacter;
    public GameObject Microwave;
    public GameObject Bowl;
    public Animator animator;
    public Animator secondaryAnimator;
    public Animator tertiaryAnimator;
    public Plate plate;
    public GameObject GameOverCanvas;
    public GameObject Button;

    public AudioSource src;
    public AudioClip sound1, sound2, sound3, sound4, sound5, sound6;


    // Metodi, joka p�ivitt�� animaatiot pistem��r�n mukaan
    public void UpdateAnimationsBasedOnScore(int score)
    {

        // K�ynnistet��n eri animaatiot riippuen pistem��r�st�
        if (score <= 50)
        {
            // Score 1 triggers
            secondaryAnimator.SetTrigger("Rajahdys");
            secondaryAnimator.SetTrigger("RajahdysMovement");
            tertiaryAnimator.SetTrigger("Mikro");
            animator.SetTrigger("KulhoMikroon");

            Invoke("TriggerExplosionEffect", 5.8f);
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
            secondaryAnimator.SetTrigger("Hyva");
            secondaryAnimator.SetTrigger("ValmisMovement");
            tertiaryAnimator.SetTrigger("Mikro");
            animator.SetTrigger("KulhoMikroon");
            animator.SetTrigger("KulhoSyonti");

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

    private void TriggerExplosionEffect()
    {
        if (explosionEffectPrefab != null && AnimatorMicro != null)
        {
            // Luodaan räjähdys efekti Micro Animated REAL objektin sijaintiin
            Instantiate(explosionEffectPrefab, AnimatorMicro.transform.position, Quaternion.identity);
        }
    }

    public void MixIngredientsButtonClicked()
    {
        Button.SetActive(false);
        Music.SetActive(false);
        AnimatorBowl.SetActive(true);
        AnimatorCaveman.SetActive(true);
        AnimatorMicro.SetActive(true);
        Bowl.SetActive(false);
        Microwave.SetActive(false);
        PlayerCharacter.SetActive(false);
        int currentScore = plate.GetTotalPoints();
        Debug.Log("Current Score: " + currentScore); // T�m� tulostaa pistem��r�n konsoliin.
        UpdateAnimationsBasedOnScore(currentScore);


        // Voit asettaa t�m�n arvon sopivaksi animaatioidesi keston mukaan

    }


    private void ShowGameOverScreen()
    {
        GameOverCanvas.SetActive(true); // Aktivoidaan GameOverCanvas
        EndMusic.SetActive(true);
        
        Debug.Log(scoreNumberText);
        if (scoreNumberText != null)
        {
            scoreNumberText.text = plate.GetTotalPoints().ToString(); // Asetetaan pisteet näkymään
        }
    }

    private void ResetAllTriggers()
    {
        // Nollaa animatorin triggerit
        ResetTriggersFor(animator);
        // Nollaa secondaryAnimatorin triggerit
        ResetTriggersFor(secondaryAnimator);
        // Nollaa tertiaryAnimatorin triggerit
        ResetTriggersFor(tertiaryAnimator);
    }

    private void ResetTriggersFor(Animator anim)
    {
        if (anim == null) return;

        var parameters = anim.parameters;
        foreach (var param in parameters)
        {
            if (param.type == AnimatorControllerParameterType.Trigger)
            {
                anim.ResetTrigger(param.name);
            }
        }
    }
}


    