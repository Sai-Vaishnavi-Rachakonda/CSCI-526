using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LeaderBoard : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite STAR0;
    public Sprite STAR1;
    public Sprite STAR2;
    public Sprite STAR3;
    public Image artworkImage;
    public string nextScene;

    public Button buttonToRemove;
   
    void Start()
    {

        if(Buttonscript.dbObj.level != null){

            switch(Buttonscript.dbObj.level.ToString()){
                case "0":
                    rating(starRating.level0Star0, starRating.level0Star1, starRating.level0Star2, starRating.level0Star3);
                break;
                case "1":
                    rating(starRating.level1Star0, starRating.level1Star1, starRating.level1Star2, starRating.level1Star3);
                break;
                case "2":
                    rating(starRating.level2Star0, starRating.level2Star1, starRating.level2Star2, starRating.level2Star3);
                break;
                case "3":
                    rating(starRating.level3Star0, starRating.level3Star1, starRating.level3Star2, starRating.level3Star3);
                break;
                case "4":
                    rating(starRating.level4Star0, starRating.level4Star1, starRating.level4Star2, starRating.level4Star3);
                break;
                case "5":
                    rating(starRating.level5Star0, starRating.level5Star1, starRating.level5Star2, starRating.level5Star3);
                break;

            }

        }
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        int sameLevel = Buttonscript.dbObj.level;
        nextScene = switchcase(sameLevel);
        // Debug.Log("Level andawnd"+nextScene);
        if (nextScene == "FinalLevel8b"){
            // Debug.Log("just checking......................");
            buttonToRemove.gameObject.SetActive(false);
        }
        
    }
    public void rating(int zero, int one, int two, int three){

       if(zero <= Buttonscript.dbObj.platformCount){
           if(STAR0){
                artworkImage.sprite = STAR0;
            } 
       }else if(one <= Buttonscript.dbObj.platformCount){
           Debug.Log("Inside 1");
           if(STAR1){
                artworkImage.sprite = STAR1;
           }
       }else if(two <= Buttonscript.dbObj.platformCount){
           Debug.Log("Inside 2");
           if(STAR2){
                artworkImage.sprite = STAR2;
           }
       }else if(STAR3){
           Debug.Log("Inside 3");
           artworkImage.sprite = STAR3;
       }
    }

    public void continueLevel(){
        // Debug.Log(Buttonscript.dbObj.level);
        UnityEngine.Debug.Log(Buttonscript.dbObj.level);
        int newLevel = Buttonscript.dbObj.level+1;
        Buttonscript.dbObj.setLevel(newLevel);
        nextScene = switchcase(newLevel);
        Debug.Log(nextScene);
        SceneManager.LoadScene(nextScene);
        Buttonscript.timePerParse.Reset();
        Buttonscript.dbObj.resetPlatformCords();
        Buttonscript.dbObj.resetPlatformCount();
        Buttonscript.dbObj.resetPlatformShoot();
        Buttonscript.dbObj.resetOrbsCollected();
        Buttonscript.dbObj.resetreasonOfLevelEnd();
        Buttonscript.dbObj.resetCheckpoint();
        Buttonscript.timePerParse.Start();
    }

    public void replayLevel(){
        // Debug.Log(Buttonscript.dbObj.level);
        int sameLevel = Buttonscript.dbObj.level;
        Debug.Log("Replay checcking the replay button" + sameLevel.ToString());
        nextScene = switchcase(sameLevel);
        Debug.Log(nextScene);
        SceneManager.LoadScene(nextScene);
    }

    public string switchcase(int level){
        string nextScene = "";
        switch(level){
            case 1:
                nextScene = "FinalLevel1";
                break;
            case 2:
                nextScene = "FinalLevel2";
                break;
            case 3:
                nextScene = "FinalLevel3a";
                break;
            case 4:
                nextScene = "FinalLevel3b";
                break;
            case 5:
                nextScene = "FinalLevel4";
                break;
            case 6:
                nextScene = "FinalLevel5";
                break;
            case 7:
                nextScene = "FinalLevel6a";
                break;
            case 8:
                nextScene = "FinalLevel6b";
                break;
            case 9:
                nextScene = "FinalLevel7";
                break;
            case 10:
                nextScene = "FinalLevel8a";
                break;
            case 11:
                nextScene = "FinalLevel8b";
                break;
        }
        return nextScene;
    }

}
