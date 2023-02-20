using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Diagnostics;
using TMPro;

public class ReloadScene : MonoBehaviour
{
    public TextMeshProUGUI Timer;
    // private System.Diagnostics.Stopwatch Stopwatch = new System.Diagnostics.Stopwatch();
    public static System.Diagnostics.Stopwatch timerParse;
    public static long timeLine;
    private AnalyticsObj dbObj = new AnalyticsObj();
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player")) //when the player hits the red ground.
        {
            Buttonscript.timePerParse.Stop();
            timeLine = Buttonscript.timePerParse.ElapsedTicks/10000000;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);// reloads the scene from the start
            Buttonscript.timePerParse.Reset();
            Buttonscript.timePerParse.Start();
            if (Buttonscript.timePerParse!= null && Timer != null && Buttonscript.timePerParse.Elapsed != null &&  Buttonscript.timePerParse.Elapsed.ToString("mm\\:ss")!= ""){
                Timer.text = "Timer: "+ Buttonscript.timePerParse.Elapsed.ToString("mm\\:ss"); 
            }
            dbObj.setTimeLine(timeLine);
            dbObj.setOutcome(0);
            FinishLine.postToDatabase(dbObj);
        }
    }
}
