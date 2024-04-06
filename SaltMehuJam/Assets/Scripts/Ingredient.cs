using UnityEngine;

public class SelfDestroyOnCollisionWithBowl : MonoBehaviour
{
    public int points = 10; // M��rittele t�m� arvo Unity Editorissa
    public string ingredientName; // Aseta t�m� Unity Editorissa kunkin ainesosan prefabille
    public GameObject ingredientPrefab; // Ved� ainesosan prefab t�h�n Unity Editorissa
    private Vector3 spawnPosition; // Alkuper�inen spawnin sijainti

    private void Start()
    {
        // Tallenna alkuper�inen sijainti spawnPosition-muuttujaan
        spawnPosition = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bowl"))
        {
            // Etsi Plate-komponentti t�rm�nneest� objektista
            Plate plate = collision.gameObject.GetComponent<Plate>() ?? collision.gameObject.GetComponentInParent<Plate>();

            if (plate != null)
            {
                // Kutsu Plate-skriptin AddIngredient-metodia ainesosan nimell�
                plate.AddIngredient(ingredientName);

                // Tulosta pistem��r� konsoliin ennen objektin tuhoamista
                Debug.Log($"Ainesosa '{ingredientName}' lis�tty. Kokonaispisteet nyt: {plate.GetTotalPoints()}");

                // Luo uusi ainesosa alkuper�iseen sijaintiin
                Instantiate(ingredientPrefab, spawnPosition, Quaternion.identity);

                // Tuhotaan t�m� objekti
                Destroy(gameObject);
            }
            else
            {
                Debug.LogWarning("Bowl-tagillisesta objektista ei l�ytynyt Plate-skripti�.");
            }
        }
    }
}
