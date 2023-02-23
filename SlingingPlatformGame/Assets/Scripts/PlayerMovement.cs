using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float jump;
    private float move;
    public bool isJumping;
    private Rigidbody2D rb;
    GameObject Slingshot,Camera, FinishLine; // @author: Chirag

    private GameObject[] platforms;  // @author: Chirag
    public Vector3 respawnPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        // @author: Chirag
        Slingshot = GameObject.Find("Slingshot");
        Camera = GameObject.Find("Main Camera");  
        FinishLine = GameObject.Find("Finish");
        respawnPosition = transform.position;


    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(speed * move, rb.velocity.y);
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
        }


        // @author: Chirag
        if(Camera.transform.position.x+1<=transform.position.x){ // moving forward
            var diff = transform.position.x - Camera.transform.position.x;
            var finishLinePosition = FinishLine.transform.position.x;
            if(Camera.transform.position.x+(9.055924)<finishLinePosition) // Camera Size: 8.055924
                Camera.transform.position = new Vector3(Camera.transform.position.x + Time.deltaTime*diff, Camera.transform.position.y, Camera.transform.position.z);
            
        }else if(Camera.transform.position.x-1>=transform.position.x){ // moving backward
            var diff = Camera.transform.position.x - transform.position.x;
            if(Camera.transform.position.x>=0) // Initial position of camera aprox 0
                Camera.transform.position = new Vector3(Camera.transform.position.x - Time.deltaTime*diff, Camera.transform.position.y, Camera.transform.position.z);
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            // @author: Chirag
            if(other.transform.position.x+2.28>transform.position.x && other.transform.position.x-2.28<=transform.position.x){
                if(other.transform.position.y+1.1>transform.position.y && other.transform.position.y-0.1<=transform.position.y){
                    Slingshot.transform.position = new Vector3(other.transform.position.x, other.transform.position.y+2f, 0);            
                }
            }
        }

        else if (other.gameObject.CompareTag("Checkpoint Flag"))
        {
            Debug.Log("entred");
            respawnPosition = transform.position;
        }
        
        else if (other.gameObject.CompareTag("Lava"))
        {
            isJumping = false;
            transform.position = respawnPosition;
            Slingshot.transform.position = new Vector3(respawnPosition.x+1f, respawnPosition.y+1.2f, 0);            
              
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        Debug.Log(other.gameObject);
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Checkpoint Flag"))
        {
            Debug.Log("entred");
            respawnPosition = transform.position;
            Slingshot.transform.position = new Vector3(respawnPosition.x+1f, respawnPosition.y+1f, 0);
            GameObject flag = GameObject.FindGameObjectWithTag("Flag Color");
            SpriteRenderer flagRendered = flag.GetComponent<SpriteRenderer>();
            flagRendered.color = Color.green;
            isJumping = false;

        }

    }
}