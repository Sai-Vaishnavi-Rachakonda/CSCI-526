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
    private AnalyticsObj dbObj = new AnalyticsObj();
    private static DateTime dt = DateTime.Now;
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
            dbObj.setTimeLine(timeLine);
            dbObj.setOutcome(1);
            postToDatabase(dbObj);
            if (player_script.ScoreNum == 2)
            {
                SceneManager.LoadScene(nextScene); //send the player to the next level.
            }
            else
            {
                Debug.Log("LoST!1");
            }
        }
    }

    public static void postToDatabase(AnalyticsObj dbObj){
        RestClient.Post("https://demodemo-96d74-default-rtdb.firebaseio.com/pre-midterm/"+dt.Month+".json", dbObj);
    }
}
