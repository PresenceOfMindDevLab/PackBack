using System;
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
    public TextMeshProUGUI outputText;
    public GameObject startButton;
    public GameObject randomizeButton;
    public GameObject randomizeText;
    [HideInInspector] public float maximumWeight = 300;
    public GameObject invalidWeightScreen;
    public Utils Utils;

    private Coroutine sortCorutine;
    private bool pauseSort = false;
    private bool startSort = false;

    public void SetWeight(string weight)
    {
        try
        {
            maximumWeight = float.Parse(weight);
            invalidWeightScreen.SetActive(false);
            return;
        }
        catch (Exception e)
        {
            invalidWeightScreen.SetActive(true);
        }
    }

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
            return getcost(y).CompareTo(getcost(x));
        });

        int invSlot = 0;
        int itemInInv = 0;
        float maxWeight = maximumWeight;

        for (int counter = 0; counter < itemslist.Count; counter++)
        {
            float itemWeight = itemslist[counter].gameObject.GetComponent<ItemValues>().weight;

            if (itemInInv < 21) //add max weight stuff
            {
                if (maxWeight >= itemWeight)
                {
                    itemslist[counter].gameObject.GetComponent<moveitemsi_inventory>().ToggleState(allInventoryItemsLocations.GetInventorySlot(invSlot));
                    itemslist[counter].inInventory = true;

                    invSlot++;
                    itemInInv++;
                    maxWeight -= itemWeight;
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

        float maxWeight = maximumWeight;
        int invSlot = 0;

        if (sortCorutine != null)
        {
            return;
        }

        for (int counter = 0; counter < Items.Length; counter++)
        {
            float itemWeight = Items[counter].gameObject.GetComponent<ItemValues>().weight;
            if (counter < 21)
            {
                if (maxWeight >= itemWeight)
                {
                    Items[counter].gameObject.GetComponent<moveitemsi_inventory>().ToggleState(allInventoryItemsLocations.GetInventorySlot(invSlot));
                    Items[counter].inInventory = true;
                    maxWeight -= itemWeight;
                    invSlot++;
                }
            }
            else
            {
                Items[counter].inInventory = false;
            }
        }
    }

    public void TakeItem(moveitemsi_inventory item)
    {
        ItemSlot slot = allInventoryItemsLocations.GetNextOpenInventorySlot();
        if (slot != null)
        {
            item.GetComponent<ItemValues>().inInventory = true;
            item.ToggleState(slot);
        }
        GetAllWeigth();
        GetAllValue();
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
            allChestItemsLocations.SetAllBlack();
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
        startSort = true;
        if(startSort)
        {
            sortCorutine = StartCoroutine(SortByGreedy_Coroutine());
            pauseSort = false;
            //startButton.SetActive(false);
        }
        
    }

    public void PauseCoroutine()
    {
        pauseSort = !pauseSort;
    }

    public IEnumerator SortByGreedy_Coroutine()
    {
        startButton.SetActive(false);
        randomizeButton.SetActive(false);
        randomizeText.SetActive(true);
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
                //startButton.SetActive(false);
                yield return new WaitForEndOfFrame();
                //startButton.SetActive(true);
            }

            itemslist[i].GetComponent<moveitemsi_inventory>().ToggleState(allChestItemsLocations.GetInventorySlot(i));
            itemslist[i].inInventory = false;
            allChestItemsLocations.GetInventorySlot(i).DisplayGreen();
            //FindObjectOfType<AudioManager>().Play("AlgTakesIt");
            yield return new WaitForSeconds(1);
        }

        allChestItemsLocations.SetAllRed();

        //Utils.setTextNull();
        float maxWeigth = maximumWeight;
        int invSlot = 0;
        int itemInInv = 0;

        for (int counter = 0; counter < itemslist.Count; counter++)
        {
            float itemWeight = itemslist[counter].gameObject.GetComponent<ItemValues>().weight;
            //string itemName = itemslist[counter].gameObject.GetComponent<ItemValues>().itemName;
            string itemName = itemslist[counter].itemName;
            if (itemInInv < 21) 
            {
                if (maxWeigth >= itemWeight)
                {
                    while (pauseSort)
                    {
                        //startButton.SetActive(false);
                        yield return new WaitForEndOfFrame();
                        //startButton.SetActive(true);
                    }
                    allChestItemsLocations.GetInventorySlot(counter).DisplayGreen();
                    string text = "Item ({0}) fits in the inventory";
                    //Utils.weightSortText(text, itemName);
                    weightSortText(text, itemName);
                    invSlot++;
                    itemInInv++;
                    maxWeigth -= itemWeight;
                    yield return new WaitForSeconds(1);
                }
            }
            else
            {
                while (pauseSort)
                {
                    //startButton.SetActive(false);
                    yield return new WaitForEndOfFrame();
                    //startButton.SetActive(true);
                }
                allChestItemsLocations.GetInventorySlot(counter).DisplayRed();
                string text = "Item ({0}) does not fit in the inventory";
                //Utils.weightSortText(text, itemName);
                weightSortText(text, itemName);
                yield return new WaitForSeconds(1);
            }
        }
        //startSort = false;
        sortCorutine = null;
        Greedy();
        yield return new WaitForSeconds(1);
        allChestItemsLocations.SetAllBlack();
        startButton.SetActive(true);
        randomizeButton.SetActive(true);
        randomizeText.SetActive(false);
    }


    void Start() {

        Utils = GetComponent<Utils>();
    }

    private void Update()
    {
        GetAllWeigth();
        GetAllValue();
    }

    public void exchangeItemText(string firstItemName, string secondItemName)
    {
        string template = "exchanged item {0} with item {1}";
        string output = string.Format(template, firstItemName, secondItemName);
        outputText.text = output.ToString();
    }

    public void weightSortText(string text, string itemName)
    {
        string output = string.Format(text, itemName);
        outputText.text = output.ToString();

    }

    public void setTextNull()
    {
        string output = " ";
        outputText.text = output.ToString();

    }

}
