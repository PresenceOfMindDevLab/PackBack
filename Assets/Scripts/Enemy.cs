using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Projectile projectileDamage;
    public GameObject deathAnimation;
    public GameObject itemDrop;
    public float animationRemove;
    public Transform itemDropPoint;

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
        //GameObject animation = Instantiate(deathAnimation, transform.position, Quaternion.identity);
        //Destroy(animation, animationRemove);
        Destroy(gameObject);

    }

    private void OnDestroy()
    {
        //drops item at iItemDropPoint position
        Instantiate(itemDrop, itemDropPoint.position, itemDrop.transform.rotation);
    }

}
