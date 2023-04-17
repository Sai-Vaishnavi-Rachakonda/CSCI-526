using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BombCollision : MonoBehaviour
{
    public GameObject[] powerups;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // collided = true;
        if(collision.gameObject.CompareTag("bomb"))
        {
            var pos = gameObject.transform;
            Destroy(collision.gameObject);
            Destroy(gameObject);
            var index = Random.Range(0, powerups.Length);
            Debug.Log("here43566445:    "+index);
            Instantiate(powerups[index],transform.position,transform.rotation);
        }

    }
}
