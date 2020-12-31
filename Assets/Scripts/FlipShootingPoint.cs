using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipShootingPoint : MonoBehaviour
{

    public GameObject player;
    public Vector3 offSet;
    private bool left;
    private float x;

    void Start()
    {
        x = offSet.x;
    }

    private void FixedUpdate()
    {
        //flip shooting point while moving
        left = player.GetComponent<Movement>().lookLeft;
        transform.position = player.transform.position + offSet;
        if(left)
        {
            offSet.x = -x;
        } else {
            offSet.x = x;
        }
    }
}
