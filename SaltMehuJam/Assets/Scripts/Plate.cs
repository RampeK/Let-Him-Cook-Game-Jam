using UnityEngine;

public class Plate : MonoBehaviour
{
    private int totalPoints = 0;

    public void AddIngredient(int points)
    {
        totalPoints += points;
    }

    public int GetTotalPoints()
    {
        return totalPoints;
    }
}
