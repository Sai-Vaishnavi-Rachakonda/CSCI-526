using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;

using UnityEngine.SceneManagement;
public class FinishLine : MonoBehaviour
{
    // Start is called before the first frame update
    public static long timeLine;
    public string nextScene;
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
            Buttonscript.timePerParse.Stop();
            timeLine = Buttonscript.timePerParse.ElapsedTicks/10000000;
            UnityEngine.Debug.Log("HEllo stopwatch - "+ Buttonscript.timePerParse.Elapsed.ToString("mm\\:ss"));
             UnityEngine.Debug.Log("HEllo stopwatch - "+ timeLine.ToString());
            postToDatabase();
            if (player_script.ScoreNum > 0)
            {
                SceneManager.LoadScene(nextScene); //send the player to the next level.
            }
            else
            {
                Debug.Log("LoST!1");
            }
        }
    }

    private void postToDatabase(){
        AnalyticsObj dbObj = new AnalyticsObj();
        RestClient.Post("https://demodemo-96d74-default-rtdb.firebaseio.com/.json", dbObj);
    }
}
