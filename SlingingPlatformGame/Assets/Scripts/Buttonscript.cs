using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Diagnostics;
using TMPro;

public class Buttonscript : MonoBehaviour
{
    public int gameStartScene;
    private System.Diagnostics.Stopwatch Stopwatch = new System.Diagnostics.Stopwatch();
    public static System.Diagnostics.Stopwatch timePerParse;
    public TextMeshProUGUI Timer;
    public void StartGame()
    {
        SceneManager.LoadScene(gameStartScene);
        timePerParse = Stopwatch.StartNew();
        // Timer.text = "Timer: 00:00";
    }

     // Update is called once per frame
    void Update()
    {
        if (timePerParse!= null && Timer != null && timePerParse.Elapsed != null &&  timePerParse.Elapsed.ToString("mm\\:ss")!= ""){
            Timer.text = "Timer: "+ timePerParse.Elapsed.ToString("mm\\:ss"); 
        }
    }
}
