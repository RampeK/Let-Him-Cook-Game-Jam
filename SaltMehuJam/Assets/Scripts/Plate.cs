using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Plate : MonoBehaviour
{
    private int items = 0;
    private int totalPoints = 0;
    private bool combinationActivated = false;
    private List<string> ingredientsList = new List<string>();
    private Dictionary<string, int> ingredientPoints = new Dictionary<string, int>
    {
        {"Ananas", 2},
        {"Pizza", 5},
        {"Piim�", -5},
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
        ingredientsList.Add(ingredientName); // Lis�� ainesosa listaan.
        if (ingredientPoints.TryGetValue(ingredientName, out int pointsValue))
        {
            totalPoints += pointsValue;
            items += 1;
        }
        CheckCombinations(); // Tarkistetaan ja logataan yhdistelm�t jokaisen lis�tyn ainesosan j�lkeen.
    }

    public void CheckCombinations()
    {
        // Erikoistapaukset ensin
        if (ingredientsList.Contains("Haarukka"))
        {
            totalPoints = -10000;
            return;
        }
        else if (ingredientsList.Count(ingredient => ingredient == "Kivi") >= 4 && ingredientsList.Contains("Vesi"))
        {
            totalPoints += 130;
        }

        // Kiinteät pisteet ananas+pizza yhdistelmälle
        if (CheckIfCombinationExists(new List<string> { "Ananas", "Pizza" }))
        {
            totalPoints = 60;
        }

        // Muita yhdistelmiä ei ole järkevää tarkistaa, jos kiinteät pisteet on jo asetettu
        if (totalPoints != 60)
        {
            CheckAndLogCombination(new List<string> { "Hiiva", "Sokeri", "Vesi" }, 70);
            CheckAndLogCombination(new List<string> { "Hiiva", "Sokeri", "Vesi", "Ananas", "Viina" }, 200);
            CheckAndLogCombination(new List<string> { "Rotta", "Piimä" }, 50);
            CheckAndLogCombination(new List<string> { "Viina", "Pizza" }, 20);
            CheckAndLogCombination(new List<string> { "Piimä", "Sokeri", "Ananas" }, 30);
            CheckAndLogCombination(new List<string> { "Rotta", "Kivi" }, -50);
            CheckAndLogCombination(new List<string> { "Hiiva", "Viina", "Rotta" }, 50);
            CheckAndLogCombination(new List<string> { "Kivi", "Sokeri" }, 25);
        }

        Debug.Log($"Väliaikainen pistemäärä: {totalPoints}");
    }

    private bool CheckIfCombinationExists(List<string> combination)
    {
        return combination.All(ingredient => ingredientsList.Contains(ingredient));
    }

    private void CheckAndLogCombination(List<string> combination, int points, bool isMaxLimit = false)
    {
        if (!combinationActivated && CheckIfCombinationExists(combination))
        {
            int comboPoints = isMaxLimit ? Mathf.Min(points, totalPoints + points) : points;
            totalPoints += comboPoints;
            Debug.Log($"Yhdistelmä: {string.Join("+", combination)} | Pistemäärä: {comboPoints}");
            combinationActivated = true; // Estetään muita yhdistelmiä tapahtumasta.
        }
    }

    public int GetTotalPoints()
    {
        return totalPoints;
    }

    public int GetItems()
    {
        return items;
    }
}