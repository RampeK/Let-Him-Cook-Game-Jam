using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Plate : MonoBehaviour
{
    private int items = 0;
    private int totalPoints = 0;
    private List<string> ingredientsList = new List<string>();
    private Dictionary<string, int> ingredientPoints = new Dictionary<string, int>
    {
        {"Ananas", 2},
        {"Pizza", 5},
        {"Piimä", -5},
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
        if (items >= 5)
        {
            // Jos viisi ainesosaa on jo lisätty, älä tee mitään.
            Debug.Log("Ei voi lisätä enempää ainesosia, raja saavutettu.");
            return;
        }

        ingredientsList.Add(ingredientName); // Lisää ainesosa listaan.
        if (ingredientPoints.TryGetValue(ingredientName, out int pointsValue))
        {
            // Tarkista, onko jo olemassa olevien pisteiden ja lisättävän ainesosan pisteiden summa yli 60
            // ja onko "Ananas" ja "Pizza" yhdistelmä jo aktiivinen.
            if (CheckIfCombinationExists(new List<string> { "Ananas", "Pizza" }))
            {
                // Jos yhdistelmä on aktiivinen, salli pisteiden laskea, mutta ei ylittää 60.
                if (totalPoints + pointsValue > 60)
                {
                    // Jos lisäys ylittäisi 60 pistettä, asetetaan pisteet suoraan 60:een.
                    totalPoints = 60;
                }
                else if (pointsValue < 0)
                {
                    // Jos lisättävä arvo on negatiivinen, sallitaan pisteiden vähentyminen.
                    totalPoints += pointsValue;
                }
            }
            else
            {
                // Jos "Ananas" ja "Pizza" yhdistelmää ei ole vielä aktivoitu, lisätään pisteet normaalisti.
                totalPoints += pointsValue;
            }

            items++;
        }
        CheckCombinations(); // Tarkistetaan ja logataan yhdistelmät jokaisen lisätyn ainesosan jälkeen.
    }


    public void CheckCombinations()
    {
        if (items >= 5)
        {
            // Jos viisi ainesosaa on jo lisätty, älä päivitä pisteitä.
            Debug.Log("Yhdistelmiä ei tarkisteta, koska raja on saavutettu.");
            return;
        }
        // Erikoistapaukset ensin
        if (ingredientsList.Contains("Haarukka"))
        {
            totalPoints = -10000;
            return;
        }

        if (ingredientsList.Count(ingredient => ingredient == "Kivi") >= 4 && ingredientsList.Contains("Vesi"))
        {
            totalPoints += 130;
        }

        // Tarkistetaan "Ananas+Pizza" yhdistelmä ja asetetaan maksimipisteet
        if (CheckIfCombinationExists(new List<string> { "Ananas", "Pizza" }) && totalPoints < 60)
        {
            totalPoints = 60; // Asetetaan pisteet suoraan 60:een, jos ne ovat alle sen
        }
        else
        {
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
        }

        Debug.Log($"Väliaikainen pistemäärä: {totalPoints}");
    }

    private bool CheckIfCombinationExists(List<string> combination)
    {
        return combination.All(ingredient => ingredientsList.Contains(ingredient));
    }

    private void CheckAndLogCombination(List<string> combination, int points, bool isMaxLimit = false)
    {
        if (CheckIfCombinationExists(combination))
        {
            int comboPoints = isMaxLimit ? Mathf.Min(points, totalPoints + points) : points;
            totalPoints += comboPoints;
            Debug.Log($"Yhdistelmä: {string.Join("+", combination)} | Pistemäärä: {comboPoints}");
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
