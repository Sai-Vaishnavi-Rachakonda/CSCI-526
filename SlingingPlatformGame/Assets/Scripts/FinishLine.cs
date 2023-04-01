using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Proyecto26;
using TMPro;

using UnityEngine.SceneManagement;
public class FinishLine : MonoBehaviour
{
    // Start is called before the first frame update
    public static long timeLine;
    private static DateTime dt = DateTime.Now;
    public string nextScene;
    public int score;
    public TextMeshProUGUI Timer;
    public GameObject level;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (Buttonscript.timePerParse!= null && Timer != null && Buttonscript.timePerParse.Elapsed != null &&  Buttonscript.timePerParse.Elapsed.ToString("mm\\:ss")!= ""){
            Timer.text = Buttonscript.timePerParse.Elapsed.ToString("mm\\:ss"); 
        } 
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))  //once the player reached the finish block
        {   
            Buttonscript.timePerParse.Stop();
            timeLine = Buttonscript.timePerParse.ElapsedTicks/10000000;
            Buttonscript.dbObj.setTimeLine(timeLine);
            Buttonscript.dbObj.setOutcome(1);

            Buttonscript.dbObj.setReasonOfLevelEnd("level completed");
            Buttonscript.dbObj.setOrbsCollected();
            postToDatabase(Buttonscript.dbObj);
            // if (player_script.ScoreNum >= score)
            if(player_script.ScoreNum ==  player_script.maxScore)
            {
                Buttonscript.dbObj.setLevel(++Buttonscript.dbObj.level);
                LevelSelection.levelCleared = Buttonscript.dbObj.level;
                Debug.Log("The level is "+ LevelSelection.levelCleared.ToString());
                SceneManager.LoadScene(nextScene); //send the player to the next level.
                Buttonscript.timePerParse.Reset();
                Buttonscript.dbObj.resetPlatformCords();
                Buttonscript.dbObj.resetPlatformCount();
                Buttonscript.dbObj.resetPlatformShoot();
                Buttonscript.dbObj.resetOrbsCollected();
                Buttonscript.dbObj.resetreasonOfLevelEnd();
                Buttonscript.dbObj.resetCheckpoint();
                Buttonscript.timePerParse.Start();
                
            }
            else
            {
                Debug.Log("LoST!1");
            }
        }
    }

    

    public static void postToDatabase(AnalyticsObj dbObj){
        RestClient.Post("https://demodemo-96d74-default-rtdb.firebaseio.com/midterm/"+dt.Month+"/"+dt.Day+".json", dbObj);
    }
}
