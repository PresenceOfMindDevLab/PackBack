using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadData : MonoBehaviour
{

    public static float[,] GetItemData()
    {

        string Item;
        int len;
        int ID;
        float Value;
        float Weight;

        len = 27;

        float[,] ItemMatrix = new float[len, 3];

        for (int i = 1; i < len; i++)
        {
            Item = "Item_" + i.ToString();
            GameObject item = GameObject.Find(Item);

            ID = item.GetComponent<ItemValues>().id;
            Value = item.GetComponent<ItemValues>().value;
            Weight = item.GetComponent<ItemValues>().weight;
            print(ID);
            ItemMatrix[i, 0] = ID;
            ItemMatrix[i, 1] = Value;
            ItemMatrix[i, 2] = Weight;

        }
        return ItemMatrix;
    }

    public static string GetItemName(int ID)   {
        string Item;
        string name;
        Item = "Item_" + ID.ToString();

        GameObject item = GameObject.Find(Item);
        name = item.GetComponent<ItemValues>().itemName;
        return name;

    }
    void run()
    {
        GetItemData();
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
