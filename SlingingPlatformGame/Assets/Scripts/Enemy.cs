using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 1.0f; // the speed at which the enemy moves
    public float leftLimit = 1.5f; // the left limit of the enemy's movement
    public float rightLimit = 4.5f; // the right limit of the enemy's movement
    public float initial_position_x;

    // void start()
    // {
    //     initial_position_x = transform.position.x;
    //     Debug.Log("initial position - "+ initial_position_x);
    // }
    // Update is called once per frame
    void Update()
    {
        // move the enemy horizontally
        Debug.Log("initial position - "+ initial_position_x);
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        // float initial_position_x = transform.position.x;
        // check if the enemy has gone past the right limit
        if (transform.position.x > initial_position_x+2.0f)
        {
            // move the enemy to the left limit
            transform.position = new Vector2(initial_position_x+2.0f, transform.position.y);
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        if (transform.position.x < initial_position_x-2.0f)
        {
            transform.position = new Vector2(initial_position_x-2.0f, transform.position.y);
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }

    // detect when the player collides with the enemy
    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.CompareTag("Player"))
    //     {
    //         // kill the player
    //         // add code here to kill the player
    //     }
    // }
}
