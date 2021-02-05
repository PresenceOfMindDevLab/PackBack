using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableRandomize : MonoBehaviour
{

    public GameObject randomizeButton;
    public void NoRandomize()
    {
        randomizeButton.SetActive(false);
    }

}
