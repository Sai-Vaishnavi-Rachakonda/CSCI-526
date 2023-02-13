using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    public static int replayNumber = 0;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player")) //when the player hits the red ground.
        {
            replayNumber ++;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);// reloads the scene from the start
        }
    }
}
