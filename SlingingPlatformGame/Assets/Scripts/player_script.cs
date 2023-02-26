using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class player_script : MonoBehaviour
{
    public Text MyscoreText;
    public static float ScoreNum;
    public static float maxScore;
    
    //public static float MaxHealth;
    // public Slider _slide;
    // public static float currentHealth;
    

    void Start()
    {
        ScoreNum = 0;
        //MyscoreText.text = "Keys Collected : " + ScoreNum + "/10";
        Scene currentScene = SceneManager.GetActiveScene ();
 
         // Retrieve the name of t$$anonymous$$s scene.
         string sceneName = currentScene.name;
 
         if (sceneName == "Level 0") 
         {
            maxScore = 1;
            MyscoreText.text = "Keys Collected : " + ScoreNum + "/" + maxScore;
            
         }
         else if(sceneName == "Level 1")
         {
            maxScore = 3;
            MyscoreText.text = "Keys Collected : " + ScoreNum + "/" + maxScore;
            
         }
        // currentHealth = 0;
        // _slide.maxValue = MaxHealth;
        // _slide.value = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if(collision.CompareTag("powerup"))
        // {
        //     //ScoreNum += 0.5f;
        //     //Destroy(collision.gameObject);
        //     // MyscoreText.text = "Energy level : " + ScoreNum + "/10";
        //     if (level == 0) 
        //     {
        //         currentHealth = currentHealth + 10;
        //     }
        //     else if(level == 1)
        //     {
        //         currentHealth = currentHealth + 3;
        //     }
            
        //     _slide.value = currentHealth;
        //     Destroy(collision.gameObject);
        // }
        if(collision.CompareTag("Key")){
            ScoreNum += 1;
            Destroy(collision.gameObject);
            MyscoreText.text = "Keys Collected : " + ScoreNum + "/" + maxScore;
        }
    }
}
