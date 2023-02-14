using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class FinishLine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))  //once the player reached the finish block
        {
<<<<<<< Updated upstream
            SceneManager.LoadScene("LEVEL2"); //send the player to the next level.
=======

            Buttonscript.timePerParse.Stop();
            timeLine = Buttonscript.timePerParse.ElapsedTicks/10000000;
            UnityEngine.Debug.Log("HEllo stopwatch - "+ Buttonscript.timePerParse.Elapsed.ToString("mm\\:ss"));
             UnityEngine.Debug.Log("HEllo stopwatch - "+ timeLine.ToString());
            postToDatabase();
            if(player_script.ScoreNum == 2)
            {
                SceneManager.LoadScene("LEVEL2");
            }  //send the player to the next level.
>>>>>>> Stashed changes
        }
    }
}
