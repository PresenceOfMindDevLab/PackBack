using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject col;

    public Projectile projectileDamage;
    public GameObject deathAnimation;
    public GameObject itemDrop;
    public float animationRemove;
    public Transform itemDropPoint;
    public bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        
        if(collider.CompareTag("Projectile"))
        {

            FindObjectOfType<AudioManager>().Play("OgreDeath");

            //GameObject animation = Instantiate(deathAnimation, transform.position, Quaternion.identity);
            //Destroy(animation, animationRemove);
            gameObject.SetActive(false);
            //Destroy(gameObject);
            DropItem();
            
        }
        

    }

    void DropItem()
    {
        FindObjectOfType<AudioManager>().Play("Success");

        FindObjectOfType<AudioManager>().Play("DropChest");

        Instantiate(itemDrop, itemDropPoint.position, itemDrop.transform.rotation);
        col.SetActive(true);
    }

    /*private void OnDestroy()
    {
        //drops item at iItemDropPoint position
        Instantiate(itemDrop, itemDropPoint.position, itemDrop.transform.rotation);
        isDead = true;
        col.SetActive(true);
    }*/

}
