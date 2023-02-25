using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float jump;
    private float move;
    public bool isJumping;

    private Rigidbody2D rb;
    GameObject Slingshot,Camera, FinishLine; // @author: Chirag

    private Collision2D currentPlatform;  // @author: Chirag

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        // @author: Chirag
        Slingshot = GameObject.Find("Slingshot");
        Camera = GameObject.Find("Main Camera");  
        FinishLine = GameObject.Find("Finish");
        

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
        if(Camera.transform.position.y+0.3<transform.position.y){
            var diff = transform.position.y - Camera.transform.position.y;
            Camera.transform.position = new Vector3(Camera.transform.position.x, Camera.transform.position.y + Time.deltaTime*diff, Camera.transform.position.z);
        }else if(Camera.transform.position.y-0.1>=transform.position.y){ // moving backward
            var diff = Camera.transform.position.y - transform.position.y;
            if(Camera.transform.position.y>=1.75) // Initial position of camera aprox 0
                Camera.transform.position = new Vector3(Camera.transform.position.x, Camera.transform.position.y - Time.deltaTime*diff, Camera.transform.position.z);
        }
        if(currentPlatform!=null){
            if(SceneManager.GetActiveScene().name!="Level 0")
                Slingshot.transform.position = new Vector3(currentPlatform.transform.position.x, currentPlatform.transform.position.y+2f, 0); 
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
                    currentPlatform = other;            
                }
            }


        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
        // throw new NotImplementedException();
    }
}