using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnalyticsObj : MonoBehaviour
{
    public long levelTimeLine;
    public string userID;
    public int  outcome;
    public int  level;
    
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

}
