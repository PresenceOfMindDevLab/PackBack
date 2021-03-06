﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class moveitemsi_inventory : MonoBehaviour, ISelectHandler
{
    // Transforms to act as start and end markers for the journey.
    public ItemSlot startMarker;
    private ItemSlot endMarker;
    public ItemSlot currentLocation;

    // Movement speed in units per second.
    public float speed = 1.0F;

    private void Start()
    {
        startMarker = transform.parent.GetComponent<ItemSlot>();
    }

    // Move to the target end position.
    void Update()
    {
        if (endMarker != null)
        {
            // Set our position as a fraction of the distance between the markers.
            transform.position = Vector3.Lerp(transform.position, endMarker.transform.position, 5 * Time.deltaTime);
            if ((transform.position - endMarker.transform.position).magnitude < 1f)
            {
                endMarker = null;
            }
        }
    }
    public void ToggleState(ItemSlot location) 
    {
        if (location == currentLocation)
        {
            return;
        }
        ItemSlot prevLocation = currentLocation;
        currentLocation.currentItem = null;
        currentLocation = location;
        if (location.currentItem != null)
        {
            location.currentItem.GetComponent<moveitemsi_inventory>().ToggleState(prevLocation);
        }
        currentLocation.currentItem = GetComponent<ItemValues>();
        endMarker = location;
    }

    public void ReturnToStart()
    {
        ToggleState(startMarker);
    }

    public void OnSelect(BaseEventData eventData)
    {
        TakeAllItems takeAllItems = GameObject.FindObjectOfType<TakeAllItems>();

        takeAllItems.TakeItem(this);
    }
}
