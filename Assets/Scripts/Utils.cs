using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Utils : MonoBehaviour
{
    public TextMeshProUGUI outputText;


    public void exchangeItemText(string firstItemName, string secondItemName)  {
        string template = "exchanged item {0} with item {1}";
        string output = string.Format(template, firstItemName, secondItemName);
        outputText.text = output.ToString();
    }

    public void weightSortText(string text, string itemName)   {
        string output = string.Format(text, itemName);
        outputText.text = output.ToString();

    }

    public void setTextNull() {
        string output = " ";
        outputText.text = output.ToString();

    }
}
