using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSoundOgre : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
 {
     if (other.gameObject.tag == "Player")
     {
         GameObject.FindWithTag("Enemy").GetComponent<Animator>().enabled = true;
     }
 }
}
