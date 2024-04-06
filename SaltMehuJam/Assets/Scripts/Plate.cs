using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Plate : MonoBehaviour
{
    private int totalPoints = 0;
    private List<string> ingredientsList = new List<string>();
    private Dictionary<string, int> ingredientPoints = new Dictionary<string, int>()
{
    {"Ananas", 2},
    {"Pizza", 5},
    {"Piim‰", -5},
    {"Haarukka", 0},
    {"Rotta", -5},
    {"Viina", 10},
    {"Kivi", -10},
    {"Hiiva", -5},
    {"Sokeri", 5},
    {"Vesi", 0},
};

    
    // T‰ss‰ metodi ottaa vastaan ainesosan nimen ja lis‰‰ sen listaan.
    public void AddIngredient(string ingredientName)
    {
        ingredientsList.Add(ingredientName);
    }

    // T‰t‰ metodia kutsutaan, kun peli p‰‰ttyy.
    public void CheckCombinations()
    {
        // Resetoidaan pisteet yhdistelmien tarkistusta varten.
        totalPoints = 0;

        // Asetetaan erityinen haarukka-logiikka.
        if (ingredientsList.Contains("Haarukka"))
        {
            totalPoints = -10000;
            Debug.Log("Yhdistelm‰: Haarukka | Pistem‰‰r‰: -10000");
            return; // Haarukka tyhjent‰‰ pisteet ja lopettaa yhdistelmien tarkistamisen.
        }
        // Erikoistapaus: "Vesi+4x Kivi". Tarkista, ett‰ listalla on nelj‰ "Kivi" ainesosaa ja "Vesi".
        if (ingredientsList.Count(ingredient => ingredient == "Kivi") >= 4 && ingredientsList.Contains("Vesi"))
        {
            totalPoints += 130; // Lis‰‰ pisteet yhdistelm‰lle.
            Debug.Log("Yhdistelm‰: Vesi+4xKivi | Pistem‰‰r‰: +130");
        }

        // Tarkistetaan erikoisyhdistelm‰t ja tulostetaan konsoliin.
        // T‰ss‰ koodissa oletetaan, ett‰ olet jo lis‰nnyt yksitt‰iset pisteet ainesosien lis‰‰misen yhteydess‰.
        CheckAndLogCombination(new List<string> { "Hiiva", "Sokeri", "Vesi" }, 70);
        CheckAndLogCombination(new List<string> { "Ananas", "Pizza" }, 60, true); // T‰m‰n yhdistelm‰n pisteet ovat maksimissaan 60.
        CheckAndLogCombination(new List<string> { "Hiiva", "Sokeri", "Vesi", "Ananas", "Viina" }, 200);
        CheckAndLogCombination(new List<string> { "Rotta", "Piim‰" }, 50);
        CheckAndLogCombination(new List<string> { "Viina", "Pizza" }, 20);
        CheckAndLogCombination(new List<string> { "Piim‰", "Sokeri", "Ananas" }, 30);
        CheckAndLogCombination(new List<string> { "Rotta", "Kivi" }, -50);
        CheckAndLogCombination(new List<string> { "Hiiva", "Viina", "Rotta" }, 50);
        CheckAndLogCombination(new List<string> { "Kivi", "Sokeri" }, 25);

        Debug.Log($"Lopullinen pistem‰‰r‰: {totalPoints}");
    }

    private void CheckAndLogCombination(List<string> combination, int points, bool isMaxLimit = false)
    {
        if (combination.All(ingredient => ingredientsList.Contains(ingredient)))
        {
            int combinationPoints = isMaxLimit ? Mathf.Min(points, totalPoints + points) : points;

            totalPoints += combinationPoints; // Lis‰t‰‰n yhdistelm‰n pisteet kokonaispisteisiin.

            Debug.Log($"Yhdistelm‰: {string.Join("+", combination)} | Pistem‰‰r‰: {combinationPoints}");
        }
    }

    public int GetTotalPoints()
    {
        return totalPoints;
    }

}

