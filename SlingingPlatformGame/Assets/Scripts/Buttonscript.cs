using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Diagnostics;

public class Buttonscript : MonoBehaviour
{
    public int gameStartScene;
    private System.Diagnostics.Stopwatch Stopwatch = new System.Diagnostics.Stopwatch();
    public static System.Diagnostics.Stopwatch timePerParse;
    public void StartGame()
    {
        SceneManager.LoadScene(gameStartScene);
        timePerParse = Stopwatch.StartNew();
    }
}
