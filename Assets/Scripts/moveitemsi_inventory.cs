using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveitemsi_inventory : MonoBehaviour
{



    // Transforms to act as start and end markers for the journey.
    public Transform startMarker;
    private Transform endMarker;

    // Movement speed in units per second.
    public float speed = 1.0F;

    // Move to the target end position.
    void Update()
    {
        if (endMarker != null)
        {
            // Set our position as a fraction of the distance between the markers.
            transform.position = Vector3.Lerp(transform.position, endMarker.position, 2 * Time.deltaTime);
            if ((transform.position - endMarker.position).magnitude < 1f)
            {
                endMarker = null;
            }
        }
    }
    public void ToggleState(Transform location) 
    {
        endMarker = location;
    }

    public void ReturnToStart()
    {
        endMarker = startMarker;
    }
}
