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
    public static AnalyticsObj dbObj = new AnalyticsObj();
    public static string userID; 
    public void StartGame()
    {
        SceneManager.LoadScene("Level 0");
        timePerParse = Stopwatch.StartNew();
        if(!PlayerPrefs.HasKey("userID")){
            System.Guid myuuid = System.Guid.NewGuid();
            string myuuidAsString = myuuid.ToString();
            PlayerPrefs.SetString("userID", myuuidAsString);
            PlayerPrefs.Save();
        }
        userID = PlayerPrefs.GetString("userID");
        dbObj.setLevel(0);
        dbObj.setuserID(userID);

    }

    // Update is called once per frame
    void Update()
    {
        if (timePerParse!= null && Timer != null && timePerParse.Elapsed != null &&  timePerParse.Elapsed.ToString("mm\\:ss")!= ""){
            Timer.text = timePerParse.Elapsed.ToString("mm\\:ss"); 
        }
    }
}
