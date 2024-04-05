using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class HandMovement : MonoBehaviour
{
    private Rigidbody rb;

    public float followSpeed = 5f; // Tune this speed to your liking

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        rb.useGravity = false; // Assuming you don't want the object to fall.
    }

    void FixedUpdate()
    {
        // Get the mouse position in screen coordinates
        Vector3 mouseScreenPosition = Input.mousePosition;
        
        // Get the distance of the object from the camera
        float distanceToScreen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        // Convert the screen position to world position within the plane of the object
        mouseScreenPosition.z = distanceToScreen;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);

        // Calculate the velocity needed to move the Rigidbody towards the target position
        Vector3 velocity = (mouseWorldPosition - rb.position) * followSpeed;
        
        // Apply the calculated velocity to the Rigidbody
        rb.velocity = new Vector3(velocity.x, velocity.y, rb.velocity.z); // Keeping the Rigidbody's original z velocity
    }
}
