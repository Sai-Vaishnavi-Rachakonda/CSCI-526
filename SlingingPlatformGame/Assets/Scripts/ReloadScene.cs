using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Diagnostics;
using TMPro;
using Debug = UnityEngine.Debug;

public class ReloadScene : MonoBehaviour
{
    public TextMeshProUGUI Timer;
    // private System.Diagnostics.Stopwatch Stopwatch = new System.Diagnostics.Stopwatch();
    public static System.Diagnostics.Stopwatch timerParse;
    public static long timeLine;
    // private AnalyticsObj dbObj = new AnalyticsObj();
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player")) //when the player hits the red ground.
        {
            
            
            // SceneManager.LoadScene(SceneManager.GetActiveScene().name);// reloads the scene from the start
            //TODO: change the analytics code to sync the addition of a checkpoint.
            Buttonscript.timePerParse.Stop();
            timeLine = Buttonscript.timePerParse.ElapsedTicks/10000000;
            Buttonscript.timePerParse.Reset();
            Buttonscript.timePerParse.Start();
            if (Buttonscript.timePerParse!= null && Timer != null && Buttonscript.timePerParse.Elapsed != null &&  Buttonscript.timePerParse.Elapsed.ToString("mm\\:ss")!= ""){
                Timer.text = Buttonscript.timePerParse.Elapsed.ToString("mm\\:ss"); 
            }
            Buttonscript.dbObj.setTimeLine(timeLine);
            Buttonscript.dbObj.setOutcome(0);
            FinishLine.postToDatabase(Buttonscript.dbObj);
            Buttonscript.dbObj.resetPlatformCords();
            Buttonscript.dbObj.resetPlatformCount();
        }
    }
}
