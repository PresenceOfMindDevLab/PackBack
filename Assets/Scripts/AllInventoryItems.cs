using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllInventoryItems : MonoBehaviour
{
    public ItemSlot[] allInventorySlots;

    public ItemSlot GetInventorySlot(int id)
    {
        return allInventorySlots[id];
    }

    public ItemSlot GetNextOpenInventorySlot()
    {
        foreach (var slot in allInventorySlots)
        {
            if (slot.currentItem == null)
            {
                return slot;
            }
        }

        return null;
    }

    public void SetAllRed()
    {
        foreach (var item in allInventorySlots)
        {
            item.DisplayRed();
        }
    }

    public void SetAllBlack()
    {
        foreach(var item in allInventorySlots)
        {
            item.DisplayBlack();
        }
    }
}
