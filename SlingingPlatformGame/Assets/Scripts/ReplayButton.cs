using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ReplayButton : MonoBehaviour
{
    public TextMeshProUGUI Timer;
    public void OnClick()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;    //Get current scene name
        if (currentSceneName == "Final Scene")        
        {
            SceneManager.LoadScene("firstPage");       //load game from the beginning if finished
        }
        else
        {
           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);       //load from the same level
        }
        
        Buttonscript.timePerParse.Stop();
        Buttonscript.timePerParse.Reset();
        Buttonscript.timePerParse.Start();
        if (Buttonscript.timePerParse!= null && Timer != null && Buttonscript.timePerParse.Elapsed != null &&  Buttonscript.timePerParse.Elapsed.ToString("mm\\:ss")!= ""){
                Timer.text = Buttonscript.timePerParse.Elapsed.ToString("mm\\:ss"); 
        }
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}


