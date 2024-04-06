using UnityEngine;

public class SelfDestroyOnCollisionWithBowl : MonoBehaviour
{
    public int points = 10; // M��rittele t�m� arvo Unity Editorissa
    public string ingredientName; // Aseta t�m� Unity Editorissa kunkin ainesosan prefabille
    public GameObject ingredientPrefab; // Ved� ainesosan prefab t�h�n Unity Editorissa
    public GameObject CheckGrid;
    public GameObject CheckBox1;
    public GameObject CheckBox2;
    public GameObject CheckBox3;
    public GameObject CheckBox4;
    public GameObject Button;
    private Vector3 spawnPosition; // Alkuper�inen spawnin sijainti

    private void Start()
    {
        spawnPosition = transform.position;
        // Tulosta t�m�n ainesosan pistearvo konsoliin.
        Debug.Log($"Ainesosan '{ingredientName}' pistearvo on: {points}");
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

                if (plate.GetItems() == 1){
                    CheckBox1.SetActive(true);
                } else if (plate.GetItems() == 2){
                    CheckBox2.SetActive(true);
                } else if (plate.GetItems() == 3){
                    CheckBox3.SetActive(true);
                } else if (plate.GetItems() == 4){
                    CheckBox4.SetActive(true);
                } else if (plate.GetItems() == 5){
                    CheckGrid.SetActive(false);
                    CheckBox1.SetActive(false);
                    CheckBox2.SetActive(false);
                    CheckBox3.SetActive(false);
                    CheckBox4.SetActive(false);
                    Button.SetActive(true);
                }
                

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
