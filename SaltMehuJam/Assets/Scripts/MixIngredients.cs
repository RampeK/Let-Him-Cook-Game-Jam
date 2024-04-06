using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixIngredients : MonoBehaviour
{
    public GameObject GameOverCanvas;

    public void MixIngredientsButtonClicked () {
        GameOverCanvas.SetActive(true);
    }
}
