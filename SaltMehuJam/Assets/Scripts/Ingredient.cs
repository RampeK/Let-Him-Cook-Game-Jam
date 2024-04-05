
using UnityEngine;

public class SelfDestroyOnCollisionWithBowl : MonoBehaviour
{
    public int points = 10; // M‰‰rittele t‰m‰ arvo Unity Editorissa
    public GameObject ingredientPrefab; // Ved‰ ainesosan prefab t‰h‰n Unity Editorissa
    private Vector3 spawnPosition; // Alkuper‰inen spawnin sijainti

    private void Start()
    {
        // Tallenna alkuper‰inen sijainti spawnPosition-muuttujaan
        spawnPosition = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bowl")
        {
            Plate plate = collision.gameObject.GetComponent<Plate>() ?? collision.gameObject.GetComponentInParent<Plate>();
            if (plate != null)
            {
                plate.AddIngredient(points);

                // Tulosta pistem‰‰r‰ konsoliin ennen objektin tuhoamista
                Debug.Log($"Ainesosa lis‰tty. Kokonaispisteet nyt: {plate.GetTotalPoints()}");

                // Luo uusi ainesosa alkuper‰iseen sijaintiin
                GameObject clone = Instantiate(ingredientPrefab, spawnPosition, Quaternion.identity);

                // Asettaa kaikki MonoBehaviour-skriptit p‰‰lle kloonissa
                foreach (MonoBehaviour script in clone.GetComponents<MonoBehaviour>())
                {
                    script.enabled = true;
                }

                // Tuhotaan t‰m‰ objekti
                Destroy(gameObject);
            }
            else
            {
                Debug.LogWarning("Plate-skripti‰ ei lˆydetty 'Bowl'-tagillisesta objektista.");
            }
        }
    }
}