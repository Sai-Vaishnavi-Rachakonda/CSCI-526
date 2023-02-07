using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
   void OnCollisionEnter2D(Collider col){


    Debug.Log("Some Object Collided");
    if (col.CompareTag("Player")){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
   }
}
