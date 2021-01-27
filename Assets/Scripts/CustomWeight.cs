using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CustomWeight : MonoBehaviour
{
    public Text WeightInputField;
    public TextMeshProUGUI weightInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void getWeight(string newWeight)
    {
        float cweight = float.Parse(newWeight);
        print(cweight);
    }

}
