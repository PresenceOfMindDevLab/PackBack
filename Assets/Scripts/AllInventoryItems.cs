using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllInventoryItems : MonoBehaviour
{
    public Transform[] allInventorySlots;

    public Transform GetInventorySlot(int id)
    {
        return allInventorySlots[id];
    }
}
