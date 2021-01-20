using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemValues : MonoBehaviour
{
    public bool inInventory = false;

    public int id;
    public float value;
    public float weight;
    public string itemName;

    public TextMeshProUGUI valueText;
    public TextMeshProUGUI weightText;
    

    private void Awake()
    {
        GetValue();
        GetWeight();
    }

    void GetValue()
    {
        float total = 0;
        total += value;
        valueText.text = total.ToString();
    }

    void GetWeight()
    {
        float total = 0;
        total += weight;
        weightText.text = total.ToString();
    }
}
