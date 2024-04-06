using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderReset : MonoBehaviour
{
    public Vector3 resetPosition; // Set this in the Inspector to the desired reset position

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger has the GrabableObject layer
        if (other.gameObject.layer == LayerMask.NameToLayer("GrabableObject"))
        {
            // Reset the object's position
            other.transform.position = resetPosition;
        }
    }
}
