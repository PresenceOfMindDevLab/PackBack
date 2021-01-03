using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public GameObject hitAnimation;
    public float effectRemove;
    public float lifetime;
    public float projectileDamage;

    private void OnTriggerEnter2D(Collider2D collider)
    {

        if(collider.CompareTag("Enemy"))
        {
            //GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            //Destroy(effect, effectRemove);
            
            Destroy(gameObject);
            //Debug.Log("getroffen");
        }
        
    }

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

}
