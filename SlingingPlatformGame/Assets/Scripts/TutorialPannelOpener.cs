using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialPannelOpener : MonoBehaviour
{
    public GameObject Pannel;
    // Start is called before the first frame update

    private Scene scene;

    void Start()
    {
        scene = SceneManager.GetActiveScene();
        if (scene.name == "Level 2")
        {
            Pannel.SetActive(true);
        }
        else
        {
            Pannel.SetActive(false);
        }
    }


    public void openPannel()
    {
        if (Pannel != null)
        {
            Pannel.SetActive(!Pannel.activeSelf);
        }
    }
}
