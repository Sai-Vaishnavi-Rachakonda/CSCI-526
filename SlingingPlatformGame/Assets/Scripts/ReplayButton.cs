using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ReplayButton : MonoBehaviour
{
    public TextMeshProUGUI Timer;
    public static long timeLine;
    public void OnClick()
    {
        Buttonscript.timePerParse.Stop();
        timeLine = Buttonscript.timePerParse.ElapsedTicks/10000000;
        Buttonscript.timePerParse.Reset();

        Buttonscript.dbObj.setTimeLine(timeLine);
        Buttonscript.dbObj.setOutcome(0);
        Buttonscript.dbObj.setReasonOfLevelEnd("manual replay");
        Buttonscript.dbObj.setOrbsCollected();
        FinishLine.postToDatabase(Buttonscript.dbObj);
        Buttonscript.dbObj.resetPlatformCords();
        Buttonscript.dbObj.resetPlatformCount();
        Buttonscript.dbObj.resetPlatformShoot();
        Buttonscript.dbObj.resetreasonOfLevelEnd();
        ButtonScript.dbObj.resetCheckpoint();
        Buttonscript.dbObj.resetOrbsCollected();

        string currentSceneName = SceneManager.GetActiveScene().name;    //Get current scene name
        if (currentSceneName == "Final Scene")        
        {
            SceneManager.LoadScene("firstPage");       //load game from the beginning if finished
        }
        else
        {
           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);       //load from the same level
        }
        
       
        Buttonscript.timePerParse.Start();
        if (Buttonscript.timePerParse!= null && Timer != null && Buttonscript.timePerParse.Elapsed != null &&  Buttonscript.timePerParse.Elapsed.ToString("mm\\:ss")!= ""){
                Timer.text = Buttonscript.timePerParse.Elapsed.ToString("mm\\:ss"); 
        }
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}


