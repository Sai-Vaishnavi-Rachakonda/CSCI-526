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

    public GameObject Pannel;
    public string levelType;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       if (Buttonscript.timePerParse!= null && Timer != null && Buttonscript.timePerParse.Elapsed != null && Buttonscript.timePerParse.Elapsed.ToString("mm\\:ss")!= ""){
            //check if panel is open and pause the timer
            if(Pannel != null && Pannel.activeSelf){
                Buttonscript.timePerParse.Stop();
                
            }
            //if panel is closed start timer
            else if(Pannel != null && !Pannel.activeSelf){
                Buttonscript.timePerParse.Start();
                Timer.text = Buttonscript.timePerParse.Elapsed.ToString("mm\\:ss"); 
            }
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
            Debug.Log("before ===");
            if(player_script.ScoreNum ==  player_script.maxScore)
            {
                Debug.Log("after ===");
                // if(levelType == "real"){
                    SceneManager.LoadScene("leaderBoard"); 
                // }else{
                //     SceneManager.LoadScene(nextScene);
                //     Buttonscript.timePerParse.Reset();
                //     Buttonscript.dbObj.resetPlatformCords();
                //     Buttonscript.dbObj.resetPlatformCount();
                //     Buttonscript.dbObj.resetPlatformShoot();
                //     Buttonscript.dbObj.resetOrbsCollected();
                //     Buttonscript.dbObj.resetreasonOfLevelEnd();
                //     Buttonscript.dbObj.resetCheckpoint();
                //     Buttonscript.timePerParse.Start();
                // }
                int level = Buttonscript.dbObj.level;
                Debug.Log("We are checking what the level is" + Buttonscript.dbObj.level.ToString());
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
