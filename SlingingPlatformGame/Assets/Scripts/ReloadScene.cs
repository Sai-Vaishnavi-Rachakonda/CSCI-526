using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player")) //when the player hits the red ground.
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);// reloads the scene from the start
        }
    }
}
