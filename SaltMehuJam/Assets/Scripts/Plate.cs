using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Plate : MonoBehaviour
{
    private int totalPoints = 0;
    private List<string> ingredientsList = new List<string>();
    private Dictionary<string, int> ingredientPoints = new Dictionary<string, int>
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

    public void AddIngredient(string ingredientName)
    {
        ingredientsList.Add(ingredientName); // Lis‰‰ ainesosa listaan.
        if (ingredientPoints.TryGetValue(ingredientName, out int pointsValue))
        {
            totalPoints += pointsValue;
        }
        CheckCombinations(); // Tarkistetaan ja logataan yhdistelm‰t jokaisen lis‰tyn ainesosan j‰lkeen.
    }

    public void CheckCombinations()
    {
        int tempTotalPoints = totalPoints; // K‰yt‰ olemassa olevia pisteit‰ v‰liaikaisena pistem‰‰r‰n‰.

        // Asetetaan erityinen haarukka-logiikka.
        if (ingredientsList.Contains("Haarukka"))
        {
            tempTotalPoints = -10000;
            // Muut yhdistelm‰t eiv‰t ole merkityksellisi‰, jos haarukka on listalla.
        }
        else
        {
            // Erikoistapaus: "Vesi+4x Kivi". Tarkista, ett‰ listalla on nelj‰ "Kivi" ainesosaa ja "Vesi".
            if (ingredientsList.Count(ingredient => ingredient == "Kivi") >= 4 && ingredientsList.Contains("Vesi"))
            {
                tempTotalPoints += 130; // Lis‰‰ pisteet yhdistelm‰lle.
            }

            // Tarkistetaan erikoisyhdistelm‰t ja lis‰t‰‰n pisteet v‰liaikaisiin pisteisiin.
            tempTotalPoints += CheckAndLogCombination(new List<string> { "Hiiva", "Sokeri", "Vesi" }, 70);
            tempTotalPoints += CheckAndLogCombination(new List<string> { "Ananas", "Pizza" }, 60, true); // T‰m‰n yhdistelm‰n pisteet ovat maksimissaan 60.
            tempTotalPoints += CheckAndLogCombination(new List<string> { "Hiiva", "Sokeri", "Vesi", "Ananas", "Viina" }, 200);
            tempTotalPoints += CheckAndLogCombination(new List<string> { "Rotta", "Piim‰" }, 50);
            tempTotalPoints += CheckAndLogCombination(new List<string> { "Viina", "Pizza" }, 20);
            tempTotalPoints += CheckAndLogCombination(new List<string> { "Piim‰", "Sokeri", "Ananas" }, 30);
            tempTotalPoints += CheckAndLogCombination(new List<string> { "Rotta", "Kivi" }, -50);
            tempTotalPoints += CheckAndLogCombination(new List<string> { "Hiiva", "Viina", "Rotta" }, 50);
            tempTotalPoints += CheckAndLogCombination(new List<string> { "Kivi", "Sokeri" }, 25);
        }

        // V‰liaikainen pistem‰‰r‰ p‰ivitet‰‰n vain, jos se on suurempi kuin olemassa olevat pisteet.
        if (tempTotalPoints > totalPoints)
        {
            totalPoints = tempTotalPoints;
        }

        Debug.Log($"V‰liaikainen pistem‰‰r‰: {totalPoints}");
    }

    private int CheckAndLogCombination(List<string> combination, int points, bool isMaxLimit = false)
    {
        int comboPoints = 0;
        if (combination.All(ingredient => ingredientsList.Contains(ingredient)))
        {
            comboPoints = isMaxLimit ? Mathf.Min(points, totalPoints + points) : points;
            Debug.Log($"Yhdistelm‰: {string.Join("+", combination)} | Pistem‰‰r‰: {comboPoints}");
        }
        return comboPoints;
    }

    public int GetTotalPoints()
    {
        return totalPoints;
    }
}
