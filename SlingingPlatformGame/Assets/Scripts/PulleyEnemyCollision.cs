using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulleyEnemyCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("bomb"))
        {
            Debug.Log("Called1");
            DownAnimation.startAnimation();
        }
    }
}
