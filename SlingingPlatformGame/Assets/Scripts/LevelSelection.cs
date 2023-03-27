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
            case "level1":
                // Debug.Log("Level1");
                SceneManager.LoadScene("Level 0");
                Buttonscript.timePerParse = Stopwatch.StartNew();
                Buttonscript.dbObj.setLevel(0);
                break;
            case "level2":
                // Debug.Log("Level2");
                SceneManager.LoadScene("Level 1"); 
                Buttonscript.timePerParse = Stopwatch.StartNew();
                Buttonscript.dbObj.setLevel(1);
                break;
            case "level3":
                // Debug.Log("Level3");
                SceneManager.LoadScene("Level 2");
                Buttonscript.timePerParse = Stopwatch.StartNew();
                Buttonscript.dbObj.setLevel(2);
                break;
            case "level4":
                // Debug.Log("Level4");
                SceneManager.LoadScene("Level 3");
                Buttonscript.timePerParse = Stopwatch.StartNew();
                Buttonscript.dbObj.setLevel(3);
                break;
            case "level5":
                // Debug.Log("Level5");
                SceneManager.LoadScene("Level 4");
                Buttonscript.timePerParse = Stopwatch.StartNew(); 
                Buttonscript.dbObj.setLevel(4);
                break;

       }
    }
}
