using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{

    public GameObject inventory;
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

    private void OnTriggerEnter2D(Collider2D collider)
    {
 
        if(collider.CompareTag("Player"))
        {
            inRange = true;

        }

    }

    private void OnTriggerExit2D(Collider2D collider)
    {

        if (collider.CompareTag("Player"))
        {
            inRange = false;

        }

    }
}
