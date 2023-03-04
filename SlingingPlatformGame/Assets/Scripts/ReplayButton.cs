using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ReplayButton : MonoBehaviour
{
    public TextMeshProUGUI Timer;
    public void OnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Buttonscript.timePerParse.Stop();
        Buttonscript.timePerParse.Reset();
        Buttonscript.timePerParse.Start();
        if (Buttonscript.timePerParse!= null && Timer != null && Buttonscript.timePerParse.Elapsed != null &&  Buttonscript.timePerParse.Elapsed.ToString("mm\\:ss")!= ""){
                Timer.text = Buttonscript.timePerParse.Elapsed.ToString("mm\\:ss"); 
        }
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}


