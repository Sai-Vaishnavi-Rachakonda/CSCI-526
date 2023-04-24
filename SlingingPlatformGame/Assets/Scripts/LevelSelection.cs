using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Diagnostics;
using TMPro;

public class LevelSelection : MonoBehaviour
{
    private System.Diagnostics.Stopwatch Stopwatch = new System.Diagnostics.Stopwatch();
    // Start is called before the first frame update
    public TextMeshProUGUI Timer;

    void Start(){
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Buttonscript.timePerParse!= null && Timer != null && Buttonscript.timePerParse.Elapsed != null &&  Buttonscript.timePerParse.Elapsed.ToString("mm\\:ss")!= ""){
                Timer.text = Buttonscript.timePerParse.Elapsed.ToString("mm\\:ss"); 
        }
        
    }

    public void selectLevel(){
       switch(this.gameObject.name.ToString())
       {
            case "Level1":
                UnityEngine.Debug.Log("Level1");
                SceneManager.LoadScene("FinalLevel1");
                Buttonscript.timePerParse = Stopwatch.StartNew();
                Buttonscript.dbObj.setLevel(0);
                break;
            case "Level2":
                    UnityEngine.Debug.Log("Level1");
                    this.gameObject.GetComponent<Image>().color = new Color(255,255,255);
                    SceneManager.LoadScene("FinalLevel2"); 
                    Buttonscript.timePerParse = Stopwatch.StartNew();
                    Buttonscript.dbObj.setLevel(1);
                break;
            case "Level3a":
                    // Debug.Log("Level3");
                    SceneManager.LoadScene("FinalLevel3a");
                    Buttonscript.timePerParse = Stopwatch.StartNew();
                    Buttonscript.dbObj.setLevel(2);
                break;
            case "Level3b":
                    // Debug.Log("Level3");
                    SceneManager.LoadScene("FinalLevel3b");
                    Buttonscript.timePerParse = Stopwatch.StartNew();
                    Buttonscript.dbObj.setLevel(3);
                break;
            case "Level4":
                    // Debug.Log("Level3");
                    SceneManager.LoadScene("FinalLevel4");
                    Buttonscript.timePerParse = Stopwatch.StartNew();
                    Buttonscript.dbObj.setLevel(4);
                break;
            case "Level5":
                    // Debug.Log("Level3");
                    SceneManager.LoadScene("FinalLevel5");
                    Buttonscript.timePerParse = Stopwatch.StartNew();
                    Buttonscript.dbObj.setLevel(5);
                break;
            case "Level6a":
                    // Debug.Log("Level3");
                    SceneManager.LoadScene("FinalLevel6a");
                    Buttonscript.timePerParse = Stopwatch.StartNew();
                    Buttonscript.dbObj.setLevel(5);
                break;
            case "Level6b":
                    // Debug.Log("Level3");
                    SceneManager.LoadScene("FinalLevel6b");
                    Buttonscript.timePerParse = Stopwatch.StartNew();
                    Buttonscript.dbObj.setLevel(5);
                break;
            case "Level7":
                    // Debug.Log("Level3");
                    SceneManager.LoadScene("FinalLevel7");
                    Buttonscript.timePerParse = Stopwatch.StartNew();
                    Buttonscript.dbObj.setLevel(5);
                break;
            case "Level8a":
                    // Debug.Log("Level3");
                    SceneManager.LoadScene("FinalLevel8a");
                    Buttonscript.timePerParse = Stopwatch.StartNew();
                    Buttonscript.dbObj.setLevel(5);
                break;
            case "Level8b":
                    // Debug.Log("Level3");
                    SceneManager.LoadScene("FinalLevel8b");
                    Buttonscript.timePerParse = Stopwatch.StartNew();
                    Buttonscript.dbObj.setLevel(5);
                break;
       }
    }


    // public static void updateLevel(int level){

    //     for(int i = 1;i<=level;i++){
    //         string levelObject = "level"+ i.ToString();
    //         GameObject obj = GameObject.Find(levelObject);
    //         obj.GetComponent<Slingshot>();
    //         obj.GetComponent<Image>().color = new Color(255,255,255);
    //         GameObject child = obj.transform.Find("lock").gameObject;
    //         child.GetComponent<Image>().enabled =false;
    //     }
    // }
}