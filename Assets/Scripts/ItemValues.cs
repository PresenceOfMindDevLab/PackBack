using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemValues : MonoBehaviour
{

    public bool inInventory = false;

    public int id;
    public float value;
    public float weight;
    public string itemName;
    private float cost;

    public TextMeshProUGUI valueText;
    public TextMeshProUGUI weightText;
    public TextMeshProUGUI costText;

    private void Awake()
    {
        Randomize();
        GetValue();
        GetWeight();
        GetCost();
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

    void GetCost()
    {
        float total = 0;
        cost = value / weight;
        total += cost;
        costText.text = total.ToString("F2");
    }

    public void Randomize()
    {
        if(inInventory)
        {
            return;
        } else
        {
            value = Random.Range(1, 50);
            weight = Random.Range(1, 50);
            GetValue();
            GetWeight();
            GetCost();
        }
        
    }
}
