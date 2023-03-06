using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AnalyticsObj : MonoBehaviour
{
    public long levelTimeLine;
    public string userID;
    public int  outcome;
    public int  level;
    public string platformCords = "";
    public int platformCount = 0;
    public string platformsShoot = "";
    public string reasonOfLevelEnd = "";
    public int defaultCount = 0;
    public int iceCount = 0;
    public string orbsCollected = "";
    public int checkpoint = 0;
    

    public void setuserID (string userID){
        this.userID = userID;
    }

    public void setOutcome (int outcome){
        this.outcome = outcome;
    }

    public void setTimeLine (long timeLine){
        this.levelTimeLine = timeLine;
    }

    public void setLevel (int level){
        this.level = level;
    }

    // public void setPlatformCords(Platform.PositionCords cords)
    public void setPlatformCords(string cords)

    {
        this.platformCords +="{"+cords+"},";
        Debug.Log(this.platformCords);
    }

    public void resetPlatformCords()
    {
        this.platformCords = "";
    }

    public void resetPlatformCount() {
        this.platformCount = 0;
    }
    public void setPlatformsShoot(string newPlatform)
    {
        this.platformsShoot += "," + newPlatform;
    }

    public void resetPlatformShoot(){
        this.platformsShoot = "";
    }

    public void setReasonOfLevelEnd(string reason){
        this.reasonOfLevelEnd = reason;
    }

    public void resetreasonOfLevelEnd(){
        this.reasonOfLevelEnd = "";
    }
    public void setOrbsCollected (){
        this.orbsCollected = "[orbs: { default: "+this.defaultCount.ToString()+", ice: "+this.iceCount.ToString()+"}]";
    }

    public void resetOrbsCollected(){
        this.orbsCollected = "";
        this.iceCount = 0;
        this.defaultCount = 0;
    }

    public void setCheckpoint(){
        this.checkpoint = 1;
    }
    public void resetCheckpoint(){
        this.checkpoint = 0;
    }

    
}
