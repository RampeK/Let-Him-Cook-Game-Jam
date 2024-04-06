using UnityEngine;

public class HandGrab : MonoBehaviour
{
    private Rigidbody rb;
    private Collider collidedObject;
    private bool isGrabbing = false;
    private Vector3 grabOffset;
    private Vector3 initialVelocity;

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

                grabOffset = collidedObject.transform.position - transform.position;

                if (collidedObject.GetComponent<Rigidbody>() != null)
                {
                    initialVelocity = collidedObject.GetComponent<Rigidbody>().velocity;
                }
            }
        }

        if (Input.GetMouseButton(0) && isGrabbing)
        {
            if (collidedObject != null)
            {
                collidedObject.transform.position = transform.position + grabOffset;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isGrabbing = false;

            if (collidedObject != null && collidedObject.GetComponent<Rigidbody>() != null)
            {
                collidedObject.GetComponent<Rigidbody>().velocity = initialVelocity;
            }
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
