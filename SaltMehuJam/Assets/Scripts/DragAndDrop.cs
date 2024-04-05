using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
    private float originalZ;

    void Start()
    {
        // Save the original z position of the object
        originalZ = gameObject.transform.position.z;
    }

    void OnMouseDown()
    {
        // Translate the object's position to the screen point
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        
        // Calculate the offset between the mouse position and the object position
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z)
        );
    }

    void OnMouseDrag()
    {
        // Keep a fixed distance from the camera
        Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        
        // Translate the mouse position to a world point at a fixed distance from the camera
        Vector3 currentWorldPoint = Camera.main.ScreenToWorldPoint(currentScreenPoint) + offset;
        
        // Keep the original z position constant
        currentWorldPoint.z = originalZ;
        
        // Update the object's position
        gameObject.transform.position = currentWorldPoint;
    }
}
