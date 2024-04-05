using UnityEngine;

public class HandGrab : MonoBehaviour
{
    private Rigidbody rb;
    private Collider collidedObject;
    private bool isGrabbing = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (collidedObject != null)
            {
                isGrabbing = true;
                rb.velocity = Vector3.zero;
            }
        }

        if (Input.GetMouseButton(0) && isGrabbing)
        {
            Vector3 mouseScreenPosition = Input.mousePosition;
            float distanceToScreen = Camera.main.WorldToScreenPoint(collidedObject.transform.position).z;
            mouseScreenPosition.z = distanceToScreen;
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);

            collidedObject.transform.position = new Vector3(mouseWorldPosition.x, mouseWorldPosition.y, collidedObject.transform.position.z);
        }

        if (Input.GetMouseButtonUp(0))
        {
            isGrabbing = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("GrabableObject"))
        {
            collidedObject = other;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other == collidedObject)
        {
            collidedObject = null;
        }
    }
}
