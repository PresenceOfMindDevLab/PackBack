using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TakeAllItems : MonoBehaviour
{
    public ItemValues[] Items;
    public AllInventoryItems allInventoryItemsLocations;
    public TextMeshProUGUI weightText;
    public TextMeshProUGUI valueText;
    private float getcost(ItemValues item) 
    {

        return item.value /item.weight;

    }
    public void Greedy()
    {
        List<ItemValues> itemslist=new List <ItemValues>(Items) ;

        itemslist.Sort(delegate (ItemValues x, ItemValues y)
        {
            if (getcost (x)  == null && getcost(y) == null) return 0;
            else if (getcost(x) == null) return -1;
            else if (getcost(y) == null) return 1;
            else return getcost(y).CompareTo(getcost (x));
        });

        for (int counter =0; counter < itemslist.Count; counter++)
        {
            if (counter < 21)
            {
                itemslist[counter].gameObject.GetComponent<moveitemsi_inventory>().ToggleState(allInventoryItemsLocations.GetInventorySlot(counter));
                itemslist[counter].inInventory = true;
            }
        }
    }

    public void Normal()
    {
        for (int counter = 0; counter < Items.Length; counter++)
        {
            if (counter < 21)
            {
                Items[counter].gameObject.GetComponent<moveitemsi_inventory>().ToggleState(allInventoryItemsLocations.GetInventorySlot(counter));
                Items[counter].inInventory = true;
            }
        }
    }

    public void UndoButton()
    {
        for (int counter = 0; counter < Items.Length; counter++)
        {
            Items[counter].gameObject.GetComponent<moveitemsi_inventory>().ReturnToStart();
            Items[counter].inInventory = false;
        }
    }

    public void GetAllValue()
    {
        float total = 0;

        foreach (var item in Items)
        {
            if (item.inInventory)
            {
                total += item.value;
            }
        }

        valueText.text = total.ToString();
    }

    public void GetAllWeigth()
    {
        float total = 0;

        foreach (var item in Items)
        {
            if (item.inInventory)
            {
                total += item.weight;
            }
        }

        weightText.text = total.ToString();
    }

    private void Update()
    {
        //GetAllValue();
        //GetAllWeigth();
    }
}
