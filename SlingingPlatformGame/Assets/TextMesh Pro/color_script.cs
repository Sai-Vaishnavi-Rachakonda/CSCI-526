using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class color_script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // GameObject door = GameObject.FindGameObjectWithTag("door color");
        // SpriteRenderer doorRendered = door.GetComponent<SpriteRenderer>();
        // doorRendered.color = Color.black;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject door = GameObject.FindGameObjectWithTag("door color");
        SpriteRenderer doorRendered = door.GetComponent<SpriteRenderer>();
        doorRendered.color = player_script.ScoreNum == player_script.maxScore ? Color.green : Color.black;
    }
}
