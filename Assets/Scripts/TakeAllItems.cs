using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TakeAllItems : MonoBehaviour
{
    public ItemValues[] Items;
    public AllInventoryItems allInventoryItemsLocations;
    public AllInventoryItems allChestItemsLocations;
    public TextMeshProUGUI weightText;
    public TextMeshProUGUI valueText;

    //public TextMeshProUGUI weightInput;

    private Coroutine sortCorutine;

    public float getcost(ItemValues item) 
    {
        return item.value / item.weight;
    }

    public void Greedy()
    {
        if (sortCorutine != null)
        {
            return;
        }

        List<ItemValues> itemslist = new List<ItemValues>(Items);

        itemslist.Sort(delegate (ItemValues x, ItemValues y)
        {
            /*  No longer needed
            if (x == null && y == null) return 0;
            else if (x == null) return -1;
            else if (y == null) return 1;
            */

            // getcost(item) == item.value / item.weight
            return getcost(y).CompareTo(getcost(x));
        });
        float maxWeigth = 220;
        int invSlot = 0;

        for (int counter = 0; counter < itemslist.Count; counter++)
        {
            float itemWeight = itemslist[counter].gameObject.GetComponent<ItemValues>().weight;

            if (counter < 21) //add max weight stuff
            {
                if (maxWeigth >= itemWeight)
                {
                    itemslist[counter].gameObject.GetComponent<moveitemsi_inventory>().ToggleState(allInventoryItemsLocations.GetInventorySlot(invSlot));
                    itemslist[counter].inInventory = true;

                    invSlot++;
                    maxWeigth -= itemWeight;
                }
            }
            else
            {
                itemslist[counter].inInventory = false;
            }
        }
    }

    public void Normal()
    {
        if (sortCorutine != null)
        {
            return;
        }
        for (int counter = 0; counter < Items.Length; counter++)
        {
            if (counter < 21)
            {
                Items[counter].gameObject.GetComponent<moveitemsi_inventory>().ToggleState(allInventoryItemsLocations.GetInventorySlot(counter));
                Items[counter].inInventory = true;
            }
            else
            {
                Items[counter].inInventory = false;
            }
        }
    }

    public void UndoButton()
    {
        if (sortCorutine != null)
        {
            return;
        }
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

    public void SortByGreedy()
    {
        sortCorutine = StartCoroutine(SortByGreedy_Coroutine());
        pauseSort = false;
    }

    private bool pauseSort = false;
    public void PauseCoroutine()
    {
        pauseSort = !pauseSort;
    }

    public IEnumerator SortByGreedy_Coroutine()
    {
        List<ItemValues> itemslist = new List<ItemValues>(Items);

        itemslist.Sort(delegate (ItemValues x, ItemValues y)
        {
            if (getcost(x) == null && getcost(y) == null) return 0;
            else if (getcost(x) == null) return -1;
            else if (getcost(y) == null) return 1;
            else return getcost(y).CompareTo(getcost(x));
        });

        allChestItemsLocations.SetAllRed();


        for (int i = 0; i < itemslist.Count; i++)
        {
            while (pauseSort)
            {
                yield return new WaitForEndOfFrame();
            }
            itemslist[i].GetComponent<moveitemsi_inventory>().ToggleState(allChestItemsLocations.GetInventorySlot(i));
            itemslist[i].inInventory = false;
            allChestItemsLocations.GetInventorySlot(i).DisplayGreen();
            //FindObjectOfType<AudioManager>().Play("AlgTakesIt");
            yield return new WaitForSeconds(2);
        }
        sortCorutine = null;
    }

    private void Update()
    {
        GetAllWeigth();
        GetAllValue();
    }
}
