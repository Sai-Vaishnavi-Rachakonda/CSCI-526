using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class player_script : MonoBehaviour
{
    public Text MyscoreText;
    public static int ScoreNum;
    public static int maxScore;
    public List<float> keysArray = new List<float>();

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
            //Debug.Log("myscore",ScoreNum);
            
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
            keysArray.Add(collision.gameObject.transform.position.x);
            keysArray.Add(collision.gameObject.transform.position.y);
            Destroy(collision.gameObject);
            MyscoreText.text = "Keys Collected : " + ScoreNum + "/" + maxScore;
        }
    }

    public void clearKeysArray()
    {
        keysArray = new List<float>();
        Debug.Log("cleared arr"+keysArray.Count);
    }

    public void updateScore()
    {
        ScoreNum -= keysArray.Count/2;
        MyscoreText.text = "Keys Collected : " + ScoreNum + "/" + maxScore;
        clearKeysArray();
        Debug.Log("in lava"+keysArray.Count+ScoreNum);

    }
}
