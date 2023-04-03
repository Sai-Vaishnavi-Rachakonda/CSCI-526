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

    void Start()
    {
        if(Buttonscript.dbObj.level > 0){
            GameObject obj = GameObject.Find("level"+Buttonscript.dbObj.level);
            switch(obj.name.ToString())
            {
                case "level1":
                    if(Buttonscript.dbObj.level >= 1){
                        updateLevel(Buttonscript.dbObj.level);
                    }
                    break;
                case "level2":
                    if(Buttonscript.dbObj.level >= 2){
                        updateLevel(Buttonscript.dbObj.level);
                    }
                    break;
                case "level3":
                    if(Buttonscript.dbObj.level >= 3){
                        updateLevel(Buttonscript.dbObj.level);
                    }
                    break;
                case "level4":
                    if(Buttonscript.dbObj.level >= 4){
                        updateLevel(Buttonscript.dbObj.level);
                    }
                    break;
                case "level6":
                    break;

            }
        }
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
            case "level0":
                UnityEngine.Debug.Log("Level1");
                SceneManager.LoadScene("Level 7");
                Buttonscript.timePerParse = Stopwatch.StartNew();
                Buttonscript.dbObj.setLevel(0);
                break;
            case "level1":
                if(Buttonscript.dbObj.level >= 1){

                    this.gameObject.GetComponent<Image>().color = new Color(255,255,255);
                    SceneManager.LoadScene("Level 6"); 
                    Buttonscript.timePerParse = Stopwatch.StartNew();
                    Buttonscript.dbObj.setLevel(1);
                }
                break;
            case "level2":
                if(Buttonscript.dbObj.level >= 2){
                    // Debug.Log("Level3");
                    SceneManager.LoadScene("Level 2");
                    Buttonscript.timePerParse = Stopwatch.StartNew();
                    Buttonscript.dbObj.setLevel(2);
                }
                break;
            // case "level3":
            //     if(Buttonscript.dbObj.level >= 3){
            //         // Debug.Log("Level4");
            //         SceneManager.LoadScene("Level 3");
            //         Buttonscript.timePerParse = Stopwatch.StartNew();
            //         Buttonscript.dbObj.setLevel(3);
            //     }
            //     break;
            // case "level4":
            //     if(Buttonscript.dbObj.level >= 4){
            //         // Debug.Log("Level5");
            //         SceneManager.LoadScene("Level 4");
            //         Buttonscript.timePerParse = Stopwatch.StartNew(); 
            //         Buttonscript.dbObj.setLevel(4);
            //     }
            //     break;
            // case "level6":
            //     // Debug.Log("Level6");
            //     SceneManager.LoadScene("Level 5");
            //     Buttonscript.timePerParse = Stopwatch.StartNew(); 
            //     Buttonscript.dbObj.setLevel(4);
            //     break;

       }
    }

    public void selectTutorial(){
        UnityEngine.Debug.Log(this.gameObject.name.ToString());
       switch(this.gameObject.name.ToString())
       {
            case "tLevel0":
                UnityEngine.Debug.Log("Level1");
                SceneManager.LoadScene("Level 0");
                Buttonscript.timePerParse = Stopwatch.StartNew();
                Buttonscript.dbObj.setLevel(0);
                break;
            case "tLevel1":
                    this.gameObject.GetComponent<Image>().color = new Color(255,255,255);
                    SceneManager.LoadScene("Level 1"); 
                    Buttonscript.timePerParse = Stopwatch.StartNew();
                    Buttonscript.dbObj.setLevel(1);

                break;
            case "tLevel2":
                    // Debug.Log("Level3");
                    SceneManager.LoadScene("Level 2");
                    Buttonscript.timePerParse = Stopwatch.StartNew();
                    Buttonscript.dbObj.setLevel(2);
                break;
            
            case "tLevel3":
                    // Debug.Log("Level3");
                    SceneManager.LoadScene("Level 2");
                    Buttonscript.timePerParse = Stopwatch.StartNew();
                    Buttonscript.dbObj.setLevel(2);
                break;
            case "tLevel4":
                    // Debug.Log("Level3");
                    SceneManager.LoadScene("Level 2");
                    Buttonscript.timePerParse = Stopwatch.StartNew();
                    Buttonscript.dbObj.setLevel(2);
                break;
       }
    }

    public static void updateLevel(int level){

        for(int i = 1;i<=level;i++){
            string levelObject = "level"+ i.ToString();
            GameObject obj = GameObject.Find(levelObject);
            obj.GetComponent<Slingshot>();
            obj.GetComponent<Image>().color = new Color(255,255,255);
            GameObject child = obj.transform.Find("lock").gameObject;
            child.GetComponent<Image>().enabled =false;
        }
    }
}