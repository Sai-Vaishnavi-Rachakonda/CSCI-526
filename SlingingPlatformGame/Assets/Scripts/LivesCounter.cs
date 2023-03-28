using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LivesCounter : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject heart1, heart2, heart3;
    public static int health;
    public float targetTime;
    public TextMeshProUGUI Timer;
    public static long timeLine;

    void Start()
    {
    	health = 3;
    	targetTime = 3f;
    	GameObject livesObj = GameObject.Find("Final_canvas 1").transform.Find("lives").gameObject;
    	heart1 = livesObj.transform.Find("heart1").gameObject;
    	heart2 = livesObj.transform.Find("heart2").gameObject;
    	heart3 = livesObj.transform.Find("heart3").gameObject;
        heart1.SetActive(true);
        heart2.SetActive(true);
        heart3.SetActive(true);
        OpenGameOver(false);
    }

    // Update is called once per frame
    void Update()
    {
        switch(health) {
            case 3:
                heart1.SetActive(true);
        	    heart2.SetActive(true);
        	    heart3.SetActive(true);
        	    break;
        	case 2:
        	    heart1.SetActive(true);
        	    heart2.SetActive(true);
        	    heart3.SetActive(false);
        	    break;
        	case 1:
        	    heart1.SetActive(true);
        	    heart2.SetActive(false);
        	    heart3.SetActive(false);
        	    break;
        	default:
        	    heart1.SetActive(false);
        	    heart2.SetActive(false);
        	    heart3.SetActive(false);
                if(targetTime == 3f)
                    OpenGameOver(true);
                else if(targetTime <= 0.0f){
                	PushStats();
                	SceneManager.LoadScene("levelSelection");
                }
                targetTime -= Time.deltaTime;
        	    break;
        }
    }

    
    void OpenGameOver(bool display)
    {
        GameObject canvasObj = GameObject.Find("Canvas2");
        if (canvasObj)
        {
            GameObject Pannel = canvasObj.transform.Find("GameOverPanel").gameObject;
            Debug.Log("Pannel---");
            if (Pannel != null)
            {
                Pannel.SetActive(display);
            }
        }
    }


    void PushStats() 
    {
        Buttonscript.timePerParse.Stop();
        timeLine = Buttonscript.timePerParse.ElapsedTicks/10000000;
        Buttonscript.timePerParse.Reset();
        Buttonscript.dbObj.setTimeLine(timeLine);
        Buttonscript.dbObj.setOutcome(0);
        Buttonscript.dbObj.setReasonOfLevelEnd("out of lives");
        Buttonscript.dbObj.setOrbsCollected();
        FinishLine.postToDatabase(Buttonscript.dbObj);
        Buttonscript.dbObj.resetPlatformCords();
        Buttonscript.dbObj.resetPlatformCount();
        Buttonscript.dbObj.resetPlatformShoot();
        Buttonscript.dbObj.resetreasonOfLevelEnd();
        Buttonscript.dbObj.resetOrbsCollected();
        Buttonscript.dbObj.resetCheckpoint();
        Buttonscript.timePerParse.Start();
    }
}

