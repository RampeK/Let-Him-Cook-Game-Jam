using UnityEngine;

public class SelfDestroyOnCollisionWithBowl : MonoBehaviour
{
    public int points = 10; // Määrittele tämä arvo Unity Editorissa
    public string ingredientName; // Aseta tämä Unity Editorissa kunkin ainesosan prefabille
    public GameObject ingredientPrefab; // Vedä ainesosan prefab tähän Unity Editorissa
    private Vector3 spawnPosition; // Alkuperäinen spawnin sijainti

    private void Start()
    {
        // Tallenna alkuperäinen sijainti spawnPosition-muuttujaan
        spawnPosition = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bowl"))
        {
            // Etsi Plate-komponentti törmänneestä objektista
            Plate plate = collision.gameObject.GetComponent<Plate>() ?? collision.gameObject.GetComponentInParent<Plate>();

            if (plate != null)
            {
                // Kutsu Plate-skriptin AddIngredient-metodia ainesosan nimellä
                plate.AddIngredient(ingredientName);

                // Tulosta pistemäärä konsoliin ennen objektin tuhoamista
                Debug.Log($"Ainesosa '{ingredientName}' lisätty. Kokonaispisteet nyt: {plate.GetTotalPoints()}");

                // Luo uusi ainesosa alkuperäiseen sijaintiin
                Instantiate(ingredientPrefab, spawnPosition, Quaternion.identity);

                // Tuhotaan tämä objekti
                Destroy(gameObject);
            }
            else
            {
                Debug.LogWarning("Bowl-tagillisesta objektista ei löytynyt Plate-skriptiä.");
            }
        }
    }
}
