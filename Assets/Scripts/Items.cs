using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Items : MonoBehaviour
{

    //public GameObject fullinventory;
    private bool inRange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
        /*if(inventory.activeInHierarchy && inRange)
        {
            inventory.SetActive(false);
        } else {
            inventory.SetActive(true);
        }*/
    }

    /*public void OnTriggerEnter2D(Collider2D col)
    {
 
        if(col.CompareTag("Player"))
        {
            inventory.SetActive(true);
        }

    }*/

     void OnTriggerEnter2D(Collider2D col)
     {
         if(col.name == "Player")
        {
            //fullinventory.SetActive(true);
            //Destroy(gameObject);
        }
     }

    private void OnTriggerExit2D(Collider2D collider)
    {

        if (collider.CompareTag("Player"))
        {
            //inRange = false;
            //Destroy(gameObject);
        }

    }
}
