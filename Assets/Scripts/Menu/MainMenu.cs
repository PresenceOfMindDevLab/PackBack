using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public Camera cam;

    public void StartGame()
    {
        //disable camera
        cam.enabled = false;
        //loading game scene
        SceneManager.LoadScene("Story");
    }

    public void ExitGame()
    {
        //Debug.Log("Exit");
        Application.Quit();
    }
}
