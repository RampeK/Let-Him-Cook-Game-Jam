using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public int points;

    private void OnTriggerEnter(Collider other)
    {
        // Tarkista, onko törmätty objekti kulho
        if (other.CompareTag("Bowl"))
        {
            // Oletetaan, että lautasella on 'Plate' skripti
            Plate plate = other.GetComponentInParent<Plate>();
            if (plate != null)
            {
                plate.AddIngredient(points);
            }

            // Ainesosa katoaa, kun se on lisätty lautaselle
            Destroy(gameObject);
        }
    }
}
