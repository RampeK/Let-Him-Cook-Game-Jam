using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public int points;

    private void OnTriggerEnter(Collider other)
    {
        // Tarkista, onko t�rm�tty objekti kulho
        if (other.CompareTag("Bowl"))
        {
            // Oletetaan, ett� lautasella on 'Plate' skripti
            Plate plate = other.GetComponentInParent<Plate>();
            if (plate != null)
            {
                plate.AddIngredient(points);
            }

            // Ainesosa katoaa, kun se on lis�tty lautaselle
            Destroy(gameObject);
        }
    }
}
