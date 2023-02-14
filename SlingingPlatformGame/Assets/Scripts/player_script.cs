using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_script : MonoBehaviour
{
    public Text MyscoreText;
    public static int ScoreNum;

    void Start()
    {
        ScoreNum = 0;
        MyscoreText.text = "Energy level : " + ScoreNum + "/2";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("powerup"))
        {
            ScoreNum += 1;
            Destroy(collision.gameObject);
            MyscoreText.text = "Energy level : " + ScoreNum + "/2";
        }
    }
}
