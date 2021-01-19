using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadData : MonoBehaviour
{

    public static float[,]  GetItemData()   {

        int i;
        int len;
        int ID;
        float Value;
        float Weight;
                
        GameObject[] Items;
        Items = GameObject.FindGameObjectsWithTag("Item");
        len = Items.Length;

        float[,] ItemMatrix = new float[len, 3];
        i = 0;
        foreach(GameObject item in Items)  {
            ID = item.GetComponent<ItemValues>().id;
            Value = item.GetComponent<ItemValues>().value;
            Weight = item.GetComponent<ItemValues>().weight;

            ItemMatrix[i, 0] = ID;
            ItemMatrix[i, 1] = Value;
            ItemMatrix[i, 2] = Weight;


            i += 1;
        }
        return ItemMatrix;
    }

    public string GetItemName(int ID)   {
        string Item;
        string name;
        Item = "Item_" + ID.ToString();

        GameObject item = GameObject.Find(Item);
        name = item.GetComponent<ItemValues>().itemName;

        return name;

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
