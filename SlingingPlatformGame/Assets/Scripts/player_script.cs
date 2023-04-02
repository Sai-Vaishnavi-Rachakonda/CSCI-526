using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class player_script : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI levelText;
    public static float ScoreNum;
    public static float maxScore;
    public List<float> keysArray = new List<float>();
    public bool shieldBoolean=false;
    
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
            if (levelText != null){
                levelText.text = "Level: 1";
            }
            maxScore = 1;
            // MyscoreText.text = "Keys Collected : " + ScoreNum + "/" + maxScore;
            if (scoreText != null){
                scoreText.text = ScoreNum + "/" + maxScore;
            }
            //Debug.Log("myscore",ScoreNum);
            
         }
         else if(sceneName == "Level 1")
         {

            if (levelText != null){
                levelText.text = "Level: 2";
            }
            maxScore = 2;
            // MyscoreText.text = "Keys Collected : " + ScoreNum + "/" + maxScore;
            if (scoreText != null){
                scoreText.text = ScoreNum + "/" + maxScore;
            }
            
         }
         else if(sceneName == "Level 2")
         {
            if (levelText != null){
                levelText.text = "Level: 3";
            }
            maxScore = 3;
            // MyscoreText.text = "Keys Collected : " + ScoreNum + "/" + maxScore;
            if (scoreText != null){
                scoreText.text = ScoreNum + "/" + maxScore;
            }
            
         }
         else if(sceneName == "Level 3")
         {

            if (levelText != null){
                levelText.text = "Level: 4";
            }
             maxScore = 2;
             // MyscoreText.text = "Keys Collected : " + ScoreNum + "/" + maxScore;
             if (scoreText != null){
                 scoreText.text = ScoreNum + "/" + maxScore;
             }
            
         }
         else if(sceneName == "Level 4")
         {

            if (levelText != null){
                levelText.text = "Level: 5";
            }
             maxScore = 3;
             // MyscoreText.text = "Keys Collected : " + ScoreNum + "/" + maxScore;
             if (scoreText != null){
                 scoreText.text = ScoreNum + "/" + maxScore;
             }
            
         }
         else if(sceneName == "Level 5")
         {

            if (levelText != null){
                levelText.text = "Level: 6";
            }
             maxScore = 8;
             // MyscoreText.text = "Keys Collected : " + ScoreNum + "/" + maxScore;
             if (scoreText != null){
                 scoreText.text = ScoreNum + "/" + maxScore;
             }
            
         }

        //Temp level
        else if(sceneName=="Level 6"){
            if(levelText!=null)
                levelText.text="Level: 7";

            GameObject shield = GameObject.Find("Shield");
            if(shield){
                shield.SetActive(false); 
            }
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
            //Debug.Log(ScoreNum);
            keysArray.Add(collision.gameObject.transform.position.x);
            keysArray.Add(collision.gameObject.transform.position.y);
            Destroy(collision.gameObject);
            // MyscoreText.text = "Keys Collected : " + ScoreNum + "/" + maxScore;
            Debug.Log(scoreText.text);
            scoreText.text = ScoreNum + "/" + maxScore;
            Debug.Log(scoreText.text);
        }

        if(collision.CompareTag("default-powerup")){
            Destroy(collision.gameObject);

            //decrease count of the platform
            GameObject deckObj = GameObject.Find("SelectPlatform");
            if (deckObj)
            {
                GameObject parentObject = deckObj.transform.Find("default").gameObject;
                Deck scriptObj = parentObject.GetComponent<Deck>();
                scriptObj.IncreaseCount();
                Buttonscript.dbObj.defaultCount++;
            }
        }

        if(collision.CompareTag("ice-powerup")){
            Destroy(collision.gameObject);

            //decrease count of the platform
            GameObject deckObj = GameObject.Find("SelectPlatform");
            if (deckObj)
            {
                GameObject parentObject = deckObj.transform.Find("ice").gameObject;
                Deck scriptObj = parentObject.GetComponent<Deck>();
                scriptObj.IncreaseCount();
                Buttonscript.dbObj.iceCount++;
            }
        }

        if(collision.CompareTag("powerUpShield")){
            Destroy(collision.gameObject);
            shieldBoolean=true;
            GameObject Panel = GameObject.Find("Panel");
            if (Panel){
                GameObject shield = Panel.transform.Find("Shield").gameObject;
                shield.SetActive(true);
            }
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
        // MyscoreText.text = "Keys Collected : " + ScoreNum + "/" + maxScore;
        Debug.Log("changingn gthe etecdtnvvrn");
        scoreText.text = ScoreNum + "/" + maxScore;
        clearKeysArray();
        Debug.Log("in lava"+keysArray.Count+ScoreNum);

    }
}
