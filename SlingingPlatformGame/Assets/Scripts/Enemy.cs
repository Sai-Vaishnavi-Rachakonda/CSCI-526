using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 1.0f; // the speed at which the enemy moves
    public float initial_position_x = 10.0f;
    public float initial_position_y = 10.0f;
    public float range = 3.0f;
    public bool vertical=false;
    private bool initial_move_direction = true;

    void start()
    {
        initial_position_x = transform.position.x;
        Debug.Log("ENEMY initial position from start function - "+ initial_position_x);
    }
    // Update is called once per frame
    void Update()
    {
        if(Time.time < 0.1)
        {
            // initial_position_x = transform.position.x;
            // initial_position_y = transform.position.y;
            Debug.Log("Initial X position: "+ initial_position_x);
            //Giving direction according to developer inspect element input
            if(vertical)
                transform.Translate(Vector2.up * speed * Time.deltaTime);
            else
                transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

        if(vertical)
        {
            if (transform.position.y > initial_position_y + range)
            {
                // move the enemy downwards
                initial_move_direction = false;
            }
            else if (transform.position.y < initial_position_y - range)
            {
                initial_move_direction = true;
            }

            if(initial_move_direction)
            {
                transform.Translate(Vector2.up * speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.down * speed * Time.deltaTime);
            }
        }
        else
        {
            if (transform.position.x > initial_position_x + range)
            {
                // move the enemy in left direction
                initial_move_direction = false;
            }
            else if (transform.position.x < initial_position_x - range)
            {
                //move the enemy in the right direction
                initial_move_direction = true;
            }

            if(initial_move_direction)
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
            }
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
