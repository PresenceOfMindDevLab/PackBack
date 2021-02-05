using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadData : MonoBehaviour
{

    Button takeAll;

    public static string GetItemName(int ID)   {
        string Item;
        string name;
        Item = "Item_" + ID.ToString();

        GameObject item = GameObject.Find(Item);
        name = item.GetComponent<ItemValues>().itemName;
        return name;

    }



    private void Awake()
    {
        takeAll = GetComponent<Button>();
        //takeAll.onClick.AddListener(() => { GetItemData(); });
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
