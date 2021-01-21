using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{

    public Image greenColor;
    public Image redColor;
    public ItemValues currentItem;

    private void Start()
    {
        ItemValues item = transform.GetComponentInChildren<ItemValues>();
        currentItem = item;
        if (currentItem != null)
        {
            currentItem.GetComponent<moveitemsi_inventory>().currentLocation = this;
        }
    }

    public void DisplayGreen()
    {
        greenColor.gameObject.SetActive(true);
        redColor.gameObject.SetActive(false);
    }

    public void DisplayRed()
    {
        greenColor.gameObject.SetActive(false);
        redColor.gameObject.SetActive(true);
    }
}
