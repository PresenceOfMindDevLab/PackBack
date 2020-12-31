using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public GameObject hitEffect;
    public float effectRemove;
    public float lifetime;

    private void OnTriggerEnter2D(Collider2D collider)
    {

        if(collider.CompareTag("Enemy"))
        {
            //GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            //Destroy(effect, effectRemove);
            Destroy(gameObject);
            Debug.Log("getroffen");
        }
        
    }

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

}
