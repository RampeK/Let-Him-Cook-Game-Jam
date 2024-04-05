using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DragAndDrop : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
    private float originalZ;
    public float followSpeed = 5f; // Tune this speed to your liking
    private Rigidbody rb;
    private bool isDragging = false;

    void Awake()
    {
        // Save the original z position of the object
        originalZ = gameObject.transform.position.z;
        rb = GetComponent<Rigidbody>();
        // Ensure that we don't mess with rotation and other forces
        rb.freezeRotation = true;
    }

    void OnMouseDown()
    {
        // Calculate the offset between the mouse position and the object position
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z)
        );
        isDragging = true;
        // When starting to drag, stop the Rigidbody's current motion
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    void OnMouseUp()
    {
        isDragging = false;
        // Do not zero out the velocity here; let it preserve the momentum
    }

    void FixedUpdate()
    {
        if (isDragging)
        {
            // Keep a fixed distance from the camera
            Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

            // Translate the mouse position to a world point at a fixed distance from the camera
            Vector3 targetPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + offset;

            // Keep the original z position constant
            targetPosition.z = originalZ;

            // Calculate the velocity needed to move the Rigidbody towards the target position
            Vector3 velocity = (targetPosition - rb.position) * followSpeed;

            // Apply the calculated velocity to the Rigidbody
            rb.velocity = new Vector3(velocity.x, velocity.y, velocity.z);
        }
        // If not dragging, do nothing and let the Rigidbody move freely
    }
}
