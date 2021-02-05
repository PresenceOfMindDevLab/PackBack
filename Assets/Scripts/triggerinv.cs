using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerinv : MonoBehaviour
{

    public GameObject fullinventory;
    public bool inRange;
    private bool itemsTaken = false;
    public bool inventoryOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player" && itemsTaken == false)
        {

            FindObjectOfType<AudioManager>().Play("OpenChest");

            //inRange = true;
            inventoryOpen = true;
            fullinventory.SetActive(true);

        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if(col.tag == "Player")
        {

            FindObjectOfType<AudioManager>().Play("CloseChest");

            //inRange = false;
            //itemsTaken = true;
            inventoryOpen = false;
            fullinventory.SetActive(false);
        }
    }
}
